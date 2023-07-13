using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractive.AdminPanel.Authorization {
    public class Token {
        public static string GetTokenPath() {
            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\VAVE\\Outsourcing\\Fractive\\AdminPanel\\auth.bin";
        }

        public static string GetAuthorizationTokenFromSystem() {
            return System.IO.File.ReadAllText(GetTokenPath());
        }
    }
}
