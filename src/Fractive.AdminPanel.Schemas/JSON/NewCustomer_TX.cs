using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractive.AdminPanel.Schemas.JSON {
    public class NewCustomer_TX {
        public string AccessToken { get; set; }
        public string Username { get; set; }
        public long DiscordID { get; set; }
        public long RobloxID { get; set; }
        public int ProductTier { get; set; } // 0-5 = Standard tiers, 6 = Custom
    }
}
