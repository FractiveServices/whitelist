using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fractive.AdminPanel.Backend {
    public class Connection {
        public static string GetConnectionString() {
            return System.IO.File.ReadAllText("C:\\VAVE_Bin\\Whitelist\\Config\\sqlconnection.txt");
        }
    }
}