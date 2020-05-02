using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\dev\spotifyConfig\config.xml");
            String clientId = doc.SelectNodes("//spotifyConfig/clientId")[0].InnerText;
            String clientSecret = doc.SelectNodes("//spotifyConfig/clientSecret")[0].InnerText;

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

        }

        private void convertBtn_Click(object sender, EventArgs e)
        {
            if (SpotifyAPI != null)
            {
                createSpotifyPlaylists();
            } else
            {
                messageLbl.Text = "Not Ready... Not Ready.. Stop That!";
            }
        }

        private void createSpotifyPlaylists()
        {
            String fileName = fileNameTB.Text;
            if (fileName != null && fileName.Length > 0)
            { //todo xml check...
                messageLbl.Text = "";
                XDocument doc = XDocument.Load(fileName); ;

                List<XElement> tracksXml = doc.Root.Element("dict").Element("dict").Elements("dict").ToList(); ;

                /* if (tracksXml. == 0)
                 {
                     messageLbl.Text += "Did not find any tracks";
                 }*/

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
                      //  messageLbl.Text += String.Format("\nFound: Name: {0} Artist: {1} Album: {2}\n", closestMatch.Name, concatArtists(closestMatch.Artists), closestMatch.Album.Name);
                    }
                    else
                    {
                     //   messageLbl.Text += "\nNOT FOUND\n";
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
            SearchItem items = SpotifyAPI.SearchItems(name + "+" + artist, SearchType.Track, 50);
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

        private void messageLbl_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
