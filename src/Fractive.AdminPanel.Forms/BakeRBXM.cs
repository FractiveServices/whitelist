using Fractive.AdminPanel.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractive.AdminPanel.Forms {
    public partial class BakeRBXM : Form {
        public BakeRBXM() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            saveFileDialog1.FileName = "mdl_" + textBox3.Text.Replace("-", "") + ".rbxmx";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                string outPath = saveFileDialog1.FileName;

                string uri = Configuration.ApiUrl + "/BakeRBXM.ashx/" + textBox3.Text;

                using (var wc = new WebClient()) {
                    wc.DownloadFile(uri, outPath);
                    MessageBox.Show("Downloaded to " + outPath);
                }
            }
        }
    }
}
