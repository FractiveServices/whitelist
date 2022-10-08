using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Core.JSON.APIJson {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root {
        public int DatabaseEntry { get; set; }
        public string Username { get; set; }
        public double UserId { get; set; }
        public bool AllowedAccess { get; set; }
    }
}
