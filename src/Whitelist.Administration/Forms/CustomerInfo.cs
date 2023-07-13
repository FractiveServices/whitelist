using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;
using Fractive.AdminPanel.Authorization;
using Fractive.AdminPanel.Shared;
using JSON = Fractive.AdminPanel.Schemas.JSON;

namespace Whitelist.Administration.Forms {
    public partial class CustomerInfo : Form {
        public CustomerInfo() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            int queryType = 0;

            if(radioButton1.Checked) {
                queryType = 0;
            }
            else if (radioButton2.Checked) {
                queryType = 1;
            }
            else if (radioButton3.Checked) {
                queryType = 2;
            }

            var jsonClass = new JSON.CustomerInfo_TX();

            jsonClass.AccessToken = Token.GetAuthorizationTokenFromSystem();
            jsonClass.Query = textBox1.Text;
            jsonClass.CheckType = queryType;

            string serialized = JsonConvert.SerializeObject(jsonClass);
            string serializedBase64 = Base64.Encode(serialized);

            string downloadPath = Configuration.ApiUrl + "/GetCustomerInfo.ashx/" + serializedBase64;

            string response = "";

            using(var wc = new WebClient()) {
                try {
                    response = wc.DownloadString(downloadPath);
                }
                catch(Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
            }

            if(response != "") {
                var deserialized = JsonConvert.DeserializeObject<JSON.CustomerInfo_RX>(response);

                textBox2.Text = deserialized.ID.ToString();
                textBox3.Text = deserialized.Username;
                textBox4.Text = deserialized.DiscordID.ToString();
                textBox5.Text = deserialized.RobloxID.ToString();
                textBox6.Text = deserialized.APIKey;
                textBox7.Text = deserialized.AccountStrikes.ToString();
                checkBox1.Checked = deserialized.AccountBanned;
                textBox8.Text = deserialized.CurrentWhitelistCount.ToString();
                textBox9.Text = deserialized.MaxAllowedWhitelists.ToString();

                if(deserialized.ProductTier == 6) {
                    comboBox1.Text = "Custom";
                }
                else {
                    comboBox1.Text = "Tier " + deserialized.ProductTier;
                }
            }
            else {
                MessageBox.Show("Unable to get response from server at " + downloadPath);
            }
        }

        private void button4_Click(object sender, EventArgs e) {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            checkBox1.Checked = false;
            textBox8.Text = "";
            textBox9.Text = "";
        }
    }
}
