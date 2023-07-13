using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractive.AdminPanel.Schemas.JSON {
    public class CustomerInfo_TX {
        public string AccessToken { get; set; }
        public string Query { get; set; }
        public int CheckType { get; set; } // 0 = Discord ID, 1 = API Key, 2 = Roblox ID
    }
}
