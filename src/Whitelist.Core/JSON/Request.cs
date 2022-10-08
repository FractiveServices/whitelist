using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Core.JSON.Request {
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root {
        public double ID { get; set; }
        public string Customer { get; set; }
    }
}
