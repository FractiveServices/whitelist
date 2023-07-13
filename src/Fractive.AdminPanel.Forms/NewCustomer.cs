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
using Fractive.AdminPanel.Shared;
using Newtonsoft.Json;

namespace Fractive.AdminPanel.Forms {
    public partial class NewCustomer : Form {
        public NewCustomer() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            var tx = new Fractive.AdminPanel.Schemas.JSON.NewCustomer_TX();

            tx.AccessToken = Fractive.AdminPanel.Authorization.Token.GetAuthorizationTokenFromSystem();
            tx.Username = textBox3.Text;
            tx.DiscordID = long.Parse(textBox4.Text);
            tx.RobloxID = long.Parse(textBox5.Text);

            switch (comboBox1.SelectedIndex) {
                case 0: { tx.ProductTier = 0; break; }
                case 1: { tx.ProductTier = 1; break; }
                case 2: { tx.ProductTier = 2; break; }
                case 3: { tx.ProductTier = 3; break; }
                case 4: { tx.ProductTier = 4; break; }
                case 5: { tx.ProductTier = 5; break; }
                case 6: { tx.ProductTier = 6; break; }
                default: { tx.ProductTier = 0; break; }
            }

            string serialized = JsonConvert.SerializeObject(tx);

            string serializedBase64 = Base64.Encode(serialized);

            string downloadPath = Configuration.ApiUrl + "/RegisterNewCustomer.ashx/" + serializedBase64;

            string response = "";

            using (var wc = new WebClient()) {
                try {
                    response = wc.DownloadString(downloadPath);
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (response != "") {
                var deserialized = JsonConvert.DeserializeObject<Schemas.JSON.NewCustomer_RX>(response);

                if(deserialized.Status == "OK") {
                    var final = new StringBuilder();

                    final.AppendLine("Customer \"" + tx.Username + "\" added.\nAPI Key: " + deserialized.APIKey);
                    final.AppendLine("Give this API key to the customer or use it to bake a RBXM");

                    string finalStr = final.ToString();

                    new RichTextDialog(finalStr).Show();
                }
                else {
                    MessageBox.Show("Unable to get response from server at " + downloadPath + "\nResponse: " + deserialized.Status);
                }
            }
            else {
                MessageBox.Show("Unable to get response from server at " + downloadPath);
            }
        }
    }
}
