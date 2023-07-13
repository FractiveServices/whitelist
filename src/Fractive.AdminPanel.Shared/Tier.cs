using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fractive.AdminPanel.Shared {
    public class Tier {
        public static int GetMaxAllowedFromTierIntID(int tierId) {
            switch(tierId) { // this is a very bad way, we should use a dictionary
                case 0: { return 50; }
                case 1: { return 100; }
                case 2: { return 250; }
                case 3: { return 500; }
                case 4: { return 800; }
                case 5: { return 1200; }
                default: { return 0; }
            }
        }

        public static string GetTierNameFromIntID(int tierId) {
            return "Tier " + tierId;
        }
    }
}
