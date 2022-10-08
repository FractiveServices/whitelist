using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Core.SQL {
    class Connection {
        public static string GetConnectionString() {
            return System.IO.File.ReadAllText("C:\\VAVE_Bin\\Whitelist\\Config\\sqlconnection.txt");
        }
    }
}
