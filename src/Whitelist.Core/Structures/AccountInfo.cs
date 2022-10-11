using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Core.Structures {
    public class AccountInfo {
        public string Name;
        public string APIKey;
        public int CurrentWhitelistCount;
        public int MaxWhitelistCount;
        public string Tier;
    }
}
