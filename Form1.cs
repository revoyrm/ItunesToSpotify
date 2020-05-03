using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace ItunesToSpotifyForm
{
    public partial class ItunesToSpotifyForm : Form
    {
        SpotifyWebAPI SpotifyAPI = null;

        public ItunesToSpotifyForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object senderForm, EventArgs e)
        {

        }
        private void loadConfigBtn_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\dev\spotifyConfig\config.xml");
            clientIdTB.Text = doc.SelectNodes("//spotifyConfig/clientId")[0].InnerText;
            clientSecretTB.Text = doc.SelectNodes("//spotifyConfig/clientSecret")[0].InnerText;
        }

        private void connectBtn_Click(object sender2, EventArgs e)
        {
            String clientId = clientIdTB.Text;
            String clientSecret = clientSecretTB.Text;

            if (clientId.Length > 0 && clientSecret.Length > 0)
            {
                AuthorizationCodeAuth auth = new AuthorizationCodeAuth(
                  clientId,
                  clientSecret,
                  "http://localhost:4002",
                  "http://localhost:4002",
                  Scope.PlaylistModifyPrivate | Scope.PlaylistModifyPublic | Scope.UserLibraryModify
                );

                auth.AuthReceived += async (sender, payload) =>
                {
                    auth.Stop();
                    Token token = await auth.ExchangeCode(payload.Code);
                    SpotifyAPI = new SpotifyWebAPI()
                    {
                        TokenType = token.TokenType,
                        AccessToken = token.AccessToken
                    };

                };
                auth.Start(); // Starts an internal HTTP Server
                auth.OpenBrowser();
            } else
            {
                messageLbl.Text = "Need both client secret and client Id. These can be found on your spotify developer page (free to create account).";
            }
        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            if (SpotifyAPI != null)
            {
                createSpotifyPlaylists();
            } else
            {
                messageLbl.Text = "Not Ready... Not Ready.. Stop That! Did you connect to Spotify?";
            }
        }

        private void createSpotifyPlaylists()
        {
            String fileName = fileNameTB.Text;
            if (fileName != null && fileName.Length > 0)
            {
                messageLbl.Text = "";
                XDocument doc = XDocument.Load(fileName); ;

                List<XElement> tracksXml = doc.Root.Element("dict").Element("dict").Elements("dict").ToList(); ;

                List<FullTrack> spotifyTracks = new List<FullTrack>();
                for (int i = 0; i < tracksXml.Count; i++)
                {
                    XElement track = tracksXml[i];
                    String name = getNode(track, "Name").Value;
                    String artist = getNode(track, "Artist").Value;
                    String album = getNode(track, "Album").Value;
                    ProgressLbl.Text = String.Format("Searching for ({0}/{1} -> Name: {2}  Artist: {3}  Album: {4} ", i + 1, tracksXml.Count, name, artist, album);

                    FullTrack spotifyTrack = searchSpotify(name, artist, album);
                    
                    if (spotifyTrack != null)
                    {
                        spotifyTracks.Add(spotifyTrack);
                    }
                    else
                    {
                        AddTrackToErrorLog(name, artist, album);
                    }
                }

                PrivateProfile profile = SpotifyAPI.GetPrivateProfile();
                if (!profile.HasError())
                {
                    String playlistName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    FullPlaylist playlist = SpotifyAPI.CreatePlaylist(profile.Id, playlistName);
                    if (!playlist.HasError()) 
                    { 
                        messageLbl.Text += "\n\nPlaylist-URI: " + playlist.Uri;
                        foreach(FullTrack spotifyTrack in spotifyTracks)
                        {
                            SpotifyAPI.AddPlaylistTrack(playlist.Id, spotifyTrack.Uri);
                        }
                    } else
                    {

                        messageLbl.Text += "\n\nERROR: " + playlist.Error.Message;
                    }
                }
                else
                {
                    messageLbl.Text += "\n\nERROR: " + profile.Error.Message;
                }

            }
            else
            {
                messageLbl.Text += "Please Choose a file";
            }
        }

        private FullTrack searchSpotify(String name, String artist, String album)
        {
            FullTrack closestMatch = null;
            SearchItem items = SpotifyAPI.SearchItems(name + " " + artist, SearchType.Track, 50);
            try
            {

                foreach(FullTrack item in items.Tracks.Items)
                {
                    String itunesFormattedArtists = concatArtists(item.Artists).Replace(",", "");
                    String itunesArtists = artist.Replace(",", "").Replace("& ", "");

                    if (itunesFormattedArtists.Equals(itunesArtists))
                    {
                        if (closestMatch == null)
                        {
                            closestMatch = item;
                        }

                        if(item.Album.Name.Equals(album))
                        {
                            closestMatch = item;
                        }
                    }
                }

            } catch (NullReferenceException e)
            {
                if (items.Error.Status == 429)
                {
                    Thread.Sleep(1000);
                    closestMatch = searchSpotify(name, artist, album);
                } else
                {
                    AddTrackToErrorLog(name, artist, album);
                }


            }
            return closestMatch;
        }

        private void AddTrackToErrorLog(String name, String artist, String album)
        {
            string[] lines = { String.Format("ItunesName: {0}", name), String.Format("ItunesArtist: {0}", artist), String.Format("ItunesAlbum: {0}", album) };
            System.IO.File.WriteAllLines(@"C:\dev\spotifyConfig\FailedConverts.txt", lines);
        }

        private String concatArtists(List<SimpleArtist> Artists)
        {
            String itunesArtistFormatStr = "";

            foreach (SimpleArtist artist in Artists)
            {
                itunesArtistFormatStr += String.Format("{0}, ", artist.Name);
            }
            return itunesArtistFormatStr.Substring(0, itunesArtistFormatStr.Length - 2);
        }

        private XElement getNode(XElement track, String key)
        {
            XElement node = track.Descendants("key").Where(x => (string)x.Value == key).FirstOrDefault();
            return node != null ? (XElement)node.NextNode : new XElement("string", "");
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            fileNameTB.Text = openFileDialog1.FileName;
        }
    }
}
