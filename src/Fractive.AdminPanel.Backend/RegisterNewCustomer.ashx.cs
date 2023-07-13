using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Fractive.AdminPanel.Shared;
using Fractive.AdminPanel.Backend.Core;

namespace Fractive.AdminPanel.Backend {
    public class RegisterNewCustomer : IHttpHandler {
        public void ProcessRequest(HttpContext context) {
            try {
                string end = context.Request.Url.AbsoluteUri.Split('/').Last();
                var deserializedReq = JsonConvert.DeserializeObject<Schemas.JSON.NewCustomer_TX>(Whitelist.Core.Encode.Base64.Decode(end));

                if (Authorization.GetIsAuthorized(deserializedReq.AccessToken) == true) {
                    try {
                        Guid guid = Guid.NewGuid();
                        string guidStr = guid.ToString();

                        using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                            con.Open();

                            var cmd = new MySqlCommand($"INSERT INTO `whitelist`.`wl_customers` (`ID`, `Username`, `DiscordID`, `RobloxID`, `Key`, `AccountStrikes`, `AccountBanned`, `CurrentWhitelistCount`, `MaxWhitelistsAllowed`, `ProductTier`) VALUES ('{Whitelist.Core.SQL.Query.GetLatestDbEntryIdStaff()}', '{deserializedReq.Username}', '{deserializedReq.DiscordID}', '{deserializedReq.RobloxID}', '{guidStr}', '0', '0', '0', '{Tier.GetMaxAllowedFromTierIntID(deserializedReq.ProductTier)}', '{Tier.GetTierNameFromIntID(deserializedReq.ProductTier)}');", con);

                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();

                            var response = new Schemas.JSON.NewCustomer_RX();
                            response.APIKey = guidStr;
                            response.Status = "OK";

                            context.Response.ContentType = "application/json";
                            context.Response.Write(JsonConvert.SerializeObject(response));

                            con.Close();
                        }
                    }
                    catch (Exception ex) {
                        var response = new Schemas.JSON.NewCustomer_RX();
                        response.Status = ex.Message;
                        context.Response.ContentType = "application/json";
                        context.Response.Write(JsonConvert.SerializeObject(response));
                    }
                }
            }
            catch (Exception ex) {
                context.Response.ContentType = "application/json";
                context.Response.Write("{\"Status\":\"" + ex.Message + "\"}");
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}