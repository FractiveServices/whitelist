using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Fractive.AdminPanel.Backend {
    /// <summary>
    /// Summary description for BakeRBXM
    /// </summary>
    public class BakeRBXM : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string end = context.Request.Url.AbsoluteUri.Split('/').Last();

            string text = File.ReadAllText("C:\\VAVE_Bin\\Whitelist\\Files\\RobloxAPI\\whitelist_base.rbxmx");
            text = text.Replace("%CUSTOMERKEY_FILLTAG%", end);

            string outName = "mdl_" + end.Replace("-", "") + ".rbxmx";
            string outPath = "C:\\VAVE_Temp\\" + outName;

            File.Create(outPath).Close();

            File.WriteAllText(outPath, text);

            context.Response.ContentType = "text/xml";
            context.Response.Write(File.ReadAllText(outPath));

            File.Delete(outPath);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}