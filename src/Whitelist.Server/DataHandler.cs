using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Whitelist.Server {
    internal class DataHandler {
        public static string GetResponse(string url) {
            string end = url.Split('/').Last();

            var deserializedReq = JsonConvert.DeserializeObject<Core.JSON.Request.Root>(Core.Encode.Base64.Decode(end));

            var data = Core.SQL.Query.GetAuthStatus(deserializedReq.Customer, deserializedReq.ID);

            string output = JsonConvert.SerializeObject(data);

            return output;
        }
    }
}
