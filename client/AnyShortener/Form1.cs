/*
 
Any Shortener is the place where you can find all the shortener at the same time.

Developed by: Giulio De Matteis (https://giulio.top)
License: MIT License

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnyShortener
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            url.Text = "http://";
        }

        private void Btn_Click(object sender, EventArgs e)
        {
  
            Uri uri = null;
            string urll = url.Text;
            if (!Uri.TryCreate(urll, UriKind.Absolute, out uri) || null == uri)

            {
                MessageBox.Show("Check the url format. The url need to be like this: http://example.com", "Any Shortener - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                // Check if url and service box are blank
                if (url.Text == "")
                {
                    MessageBox.Show("You need to type an url.", "Any Shortener - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (service.Text == "")
                {
                    MessageBox.Show("You need to select a shortening service.", "Any Shortener - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    try
                    {
                        // Shortener
                        if (service.Text == "is.gd")
                        {

                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("https://is.gd/create.php?format=simple&url=" + url.Text);

                            shorturl.Text = shortener;
                            panel1.Visible = true;
                        }

                        if (service.Text == "v.gd")
                        {

                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("https://v.gd/create.php?format=simple&url=" + url.Text);

                            shorturl.Text = shortener;
                            panel1.Visible = true;
                        }


                        if (service.Text == "rebrand.ly")
                        {
                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("https://code.giulio.top/dev/anyshortener/rebrandly.php?url=" + url.Text);

                            shorturl.Text = shortener;
                            panel1.Visible = true;
                        }


                        if (service.Text == "bit.ly")
                        {
                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("https://code.giulio.top/dev/anyshortener/bitly.php?url=" + url.Text);

                            shorturl.Text = shortener;
                            panel1.Visible = true;
                        }


                        if (service.Text == "cutt.ly")
                        {
                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("https://code.giulio.top/dev/anyshortener/cuttly.php?url=" + url.Text);

                            shorturl.Text = shortener;
                            panel1.Visible = true;
                        }

                        if (service.Text == "7th.it")
                        {
                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("https://code.giulio.top/dev/anyshortener/7th.php?url=" + url.Text);

                            shorturl.Text = shortener;
                            panel1.Visible = true;
                        }


                        if (service.Text == "dot.tk")
                        {
                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("http://api.dot.tk/tweak/shorten?long=" + url.Text);
                            url.Text = shortener;
                            shorturl.Text = url.Lines[0];
                            panel1.Visible = true;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("There was an error with your request.", "Any Shortener - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            url.Clear();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/themagiulio/AnyShortener/");
        }

    }
}
