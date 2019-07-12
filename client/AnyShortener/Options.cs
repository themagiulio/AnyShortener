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

namespace AnyShortener
{
    public partial class Options : Form
    {
        private string config = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AnyShortener\\config.ini";
        public Options()
        {
            InitializeComponent();
            if (File.Exists(config))
            {
                try
                {
                    string defservice = File.ReadLines(config).Skip(0).Take(1).First();
                    serviceoption.Text = defservice;
                }
                catch { }
            }
            else { }
        }

        private void Saveoptionsbtn_Click(object sender, EventArgs e)
        {
            string[] lines = { "" + serviceoption.Text};
            System.IO.File.WriteAllLines(config, lines);
            MessageBox.Show("Options saved.", "Any Shortener - Options");
            Application.Restart();
        }
    }
}
