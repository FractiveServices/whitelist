using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractive.AdminPanel.Schemas.JSON {
    public class NewCustomer_RX {
        public string Status { get; set; } // Should always be "OK", or return an exception message
        public string APIKey { get; set; }
    }
}
