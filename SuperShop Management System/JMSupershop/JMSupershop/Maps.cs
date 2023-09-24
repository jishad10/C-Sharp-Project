using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JMSupershop
{
    public partial class Maps : Form
    {
        public Maps()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
        }
        void back()
        {
           
        }


        private void backbtn_Click(object sender, EventArgs e)
        {
            
                this.Hide();
                Dashbord dashbord = new Dashbord();
                dashbord.Show();

        }

        private void Maps_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void mapbut_Click(object sender, EventArgs e)
        {
            StringBuilder queryaddress = new StringBuilder();
            queryaddress.Append("https://www.bing.com/maps?cp=23.810475%7E90.412674&lvl=11.0");

            // Navigate the web browser control to the constructed URL
            string url = queryaddress.ToString();
            if (Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                try
                {
                    webBrowser1.Navigate(url);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error navigating to URL: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid URL. Please enter valid address details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
