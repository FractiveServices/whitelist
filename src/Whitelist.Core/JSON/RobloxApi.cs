using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Core.JSON.RobloxApi {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root {
        public double Id { get; set; }
        public string Username { get; set; }
        public object AvatarUri { get; set; }
        public bool AvatarFinal { get; set; }
        public bool IsOnline { get; set; }
    }
}
