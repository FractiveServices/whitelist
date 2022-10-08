using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Core.Discord {
    public class Customer {
        public static string GetCustomerIDFromDiscordID(long discordId) {
            return SQL.Query.GetCustomerIdFromDiscordId(discordId);
        }
    }
}
