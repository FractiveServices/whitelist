using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whitelist.Administration {
    public partial class Form1 : Form {
        Forms.CustomerInfo pnl_CustomerInfo = new Forms.CustomerInfo();
        Fractive.AdminPanel.Forms.NewCustomer pnl_NewCustomer = new Fractive.AdminPanel.Forms.NewCustomer();
        Fractive.AdminPanel.Forms.BakeRBXM pnl_BakeRBXM = new Fractive.AdminPanel.Forms.BakeRBXM();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            pnl_CustomerInfo.MdiParent = this;
            pnl_NewCustomer.MdiParent = this;
            pnl_BakeRBXM.MdiParent = this;

            // Fractive :: Administration Panel (Logged in as {discordId})
        }

        private void customerInfoLookupToolStripMenuItem_Click(object sender, EventArgs e) {
            if (customerInfoLookupToolStripMenuItem.Checked) {
                pnl_CustomerInfo.Show();
            }
            else {
                pnl_CustomerInfo.Hide();
            }
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e) {
            if(newCustomerToolStripMenuItem.Checked) {
                pnl_NewCustomer.Show();
            }
            else {
                pnl_NewCustomer.Hide();
            }
        }

        private void bakeRBXMToolStripMenuItem_Click(object sender, EventArgs e) {
            if(bakeRBXMToolStripMenuItem.Checked) {
                pnl_BakeRBXM.Show();
            }
            else {
                pnl_BakeRBXM.Hide();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
