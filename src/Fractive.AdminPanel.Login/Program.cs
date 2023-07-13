using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractive.AdminPanel.Login {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(File.ReadAllText(Authorization.Token.GetTokenPath()) == "") {
                Application.Run(new Form1());
            }
            else {
                MessageBox.Show("You are already logged in. To log in with a different Fractive account, please sign out first.");
                Application.Exit();
            }
        }
    }
}
