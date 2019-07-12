/*
 
The spiciest shortener ;)
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
        private string savePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AnyShortener\\";
        public Form1()
        {
            InitializeComponent();
            url.Text = "http://example.com";

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }


            if (File.Exists(savePath + "config.ini"))
            {
                try
                {
                    string defservice = File.ReadLines(savePath + "config.ini").Skip(0).Take(1).First();
                    service.Text = defservice;
                }
                catch { }
            }
            else {
                File.Create(savePath + "config.ini").Close();
            }
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

                        if (service.Text == "shorte.st")
                        {
                            WebClient myWebClient = new WebClient();
                            string shortener = myWebClient.DownloadString("https://code.giulio.top/dev/anyshortener/shortest.php?url=" + url.Text);
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

        private void Button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(shorturl.Text);
            MessageBox.Show("The shortened url has been copyed to the clipboard.", "Any Shortener", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Any Shortener is fully developed by Giulio De Matteis. \n\nWebsite: https://giulio.top \nGithub: https://github.com/themagiulio \nInstagram: @themagiulio \nTwitter: @themagiulio \n\nYou can find more info about Any Shortener on my repo: https://github.com/themagiulio/AnyShortener", "Any Shortener - About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GithubToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            System.Diagnostics.Process.Start("https://github.com/themagiulio/AnyShortener");
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Options frm = new Options();
            frm.Show();
        }

        private void APIKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Under developing...
        }
    }
}
