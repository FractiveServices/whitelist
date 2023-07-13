using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractive.AdminPanel.Schemas.JSON {
    public class CustomerInfo_RX {
        public long ID { get; set; }
        public string Username { get; set; }
        public long DiscordID { get; set; }
        public long RobloxID { get; set; }
        public string APIKey { get; set; }
        public int AccountStrikes { get; set; }
        public bool AccountBanned { get; set; }
        public int CurrentWhitelistCount { get; set; }
        public int MaxAllowedWhitelists { get; set; }
        public int ProductTier { get; set; } // 0-5 = Standard tiers, 6 = Custom
    }
}
