using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Whitelist.Administration {
    internal static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.ReadAllText(Fractive.AdminPanel.Authorization.Token.GetTokenPath()) != "") {
                Application.Run(new Form1());
            }
            else {
                Process.Start("Login.exe");
                Application.Exit();
            }
        }
    }
}
