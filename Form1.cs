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
using SpotifyAPI.Web;
using SpotifyAPI.Web.Auth;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;

namespace ItunesToSpotifyForm
{
    public partial class Form1 : Form
    {
        SpotifyWebAPI SpotifyAPI = null;

        public Form1()
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
                this.messageLbl.Text = "Not Ready... Not Ready.. Stop That!";
            }
        }

        private void createSpotifyPlaylists()
        {
            this.messageLbl.Text = "Ready!";
        }

        private void messageLbl_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
