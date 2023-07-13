using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fractive.AdminPanel.Backend.Core;

namespace Fractive.AdminPanel.Backend {
    /// <summary>
    /// Summary description for GetCustomerInfo
    /// </summary>
    public class GetCustomerInfo : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            try {
                string end = context.Request.Url.AbsoluteUri.Split('/').Last();
                var deserializedReq = JsonConvert.DeserializeObject<Schemas.JSON.CustomerInfo_TX>(Whitelist.Core.Encode.Base64.Decode(end));

                if (Authorization.GetIsAuthorized(deserializedReq.AccessToken) == true) {
                    using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                        con.Open();

                        var cmd = new MySqlCommand();

                        switch (deserializedReq.CheckType) {
                            case 0: {
                                    cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_customers WHERE DiscordID = {deserializedReq.Query};", con);
                                    break;
                                }
                            case 1: { // THIS CURRENTLY DOESNT WORK
                                    cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_customers WHERE \"Key\" = \"{deserializedReq.Query}\";", con);
                                    break;
                                }
                            case 2: {
                                    cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_customers WHERE RobloxID = {deserializedReq.Query};", con);
                                    break;
                                }
                        }

                        MySqlDataReader rdr = cmd.ExecuteReader();

                        var response = new Schemas.JSON.CustomerInfo_RX();

                        while (rdr.Read()) {
                            response.ID = rdr.GetInt16(0);
                            response.Username = rdr.GetString(1);
                            response.DiscordID = Convert.ToInt64(rdr.GetDouble(2));
                            response.RobloxID = Convert.ToInt64(rdr.GetDouble(3));
                            response.APIKey = rdr.GetString(4);
                            response.AccountStrikes = rdr.GetInt16(5);
                            response.AccountBanned = rdr.GetBoolean(6);
                            response.CurrentWhitelistCount = rdr.GetInt16(8);
                            response.MaxAllowedWhitelists = rdr.GetInt16(9);
                        }

                        context.Response.ContentType = "application/json";
                        context.Response.Write(JsonConvert.SerializeObject(response));

                        con.Close();
                    }
                }
                else {
                    context.Response.ContentType = "application/json";
                    context.Response.Write("{\"Status\":\"Access denied\"}");
                }
            }
            catch (Exception ex) {
                //context.Response.ContentType = "application/json";
                //context.Response.Write("{\"Status\":\"" + ex.Message + "\"}");

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