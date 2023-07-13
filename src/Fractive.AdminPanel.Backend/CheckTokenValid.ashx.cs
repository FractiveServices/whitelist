using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fractive.AdminPanel.Backend {
    /// <summary>
    /// Summary description for CheckTokenValid
    /// </summary>
    public class CheckTokenValid : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            string end = context.Request.Url.AbsoluteUri.Split('/').Last();

            bool isValid = false;

            try {
                using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                    con.Open();

                    var cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_staff WHERE CurrentAccessToken = \"{end}\";", con);

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read()) {
                        if(rdr.GetString(5) == end) {
                            isValid = true;
                        }
                    }

                    context.Response.ContentType = "text/plain";
                    context.Response.Write(isValid.ToString());

                    con.Close();
                }
            }
            catch(Exception ex) {
                context.Response.ContentType = "text/plain";
                context.Response.Write(ex.Message);
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}