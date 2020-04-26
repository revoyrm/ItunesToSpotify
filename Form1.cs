using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
              Scope.PlaylistReadPrivate | Scope.PlaylistReadCollaborative
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

                // List<ItunesToSpotify.Track> tracks = new List<Track>();

                IEnumerable<XElement> tracksXml = doc.Root.Element("dict").Element("dict").Elements("dict");

               /* if (tracksXml. == 0)
                {
                    messageLbl.Text += "Did not find any tracks";
                }*/
                foreach (XElement track in tracksXml)
                {
                    var name = getNode(track, "Name").Value;
                    var artist = getNode(track, "Artist").Value;
                    var album = getNode(track, "Album").Value;
                    messageLbl.Text += String.Format("Name: {0}  Artist: {1}  Album: {2}  \n", name, artist, album);
                }
            }
            else
            {
                messageLbl.Text += "Please Choose a file";
            }
        }

        private XElement getNode(XElement track, String key)
        {
            return (XElement)track.Descendants("key").Where(x => (string)x.Value == key).FirstOrDefault().NextNode;
        }

        private void createSpotifyPlaylistsXmlDox()
        {
            String fileName = fileNameTB.Text;
            if (fileName != null && fileName.Length > 0)
            { //todo xml check...
                messageLbl.Text = "";
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);

                // List<ItunesToSpotify.Track> tracks = new List<Track>();

                var tracksXml = doc.SelectNodes("//dict/dict/dict");
                
                if (tracksXml.Count == 0)
                {
                    messageLbl.Text += "Did not find any tracks";
                }
                foreach (XmlNode track in tracksXml)
                {
                    string name = track.SelectNodes("//[key/text() = 'Name']/string")[0].InnerText;
                    string artist = track.SelectNodes("//[key/text() = 'Artist']/string")[0].InnerText;
                    string album = track.SelectNodes("//[key/text() = 'Album']/string")[0].InnerText;
                    messageLbl.Text += String.Format("Name: {0}  Artist: {1}  Album: {2}  \n", name, artist, album);
                }
            } else
            {
                messageLbl.Text += "Please Choose a file";
            }
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
