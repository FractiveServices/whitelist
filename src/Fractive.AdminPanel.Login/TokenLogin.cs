using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractive.AdminPanel.Login {
    public partial class TokenLogin : Form {
        public TokenLogin() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                using (var wc = new WebClient()) {
                    if (bool.Parse(wc.DownloadString(Shared.Configuration.ApiUrl + "/CheckTokenValid.ashx/" + textBox1.Text))) {
                        File.WriteAllText(Authorization.Token.GetTokenPath(), textBox1.Text);

                        MessageBox.Show("Logged in successfully.");

                        Process.Start("FractiveAdministration.exe");
                        Application.Exit();
                    }
                    else {
                        MessageBox.Show("Invalid token.");
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
