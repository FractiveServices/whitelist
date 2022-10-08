// #######################################################
// Copyright (c) VAVE 2022. All rights reserved.
// VAVE CONFIDENTIAL AND PROPRIETARY
// 
// File: Query.cs
// Description: SQL querying manager
// 
// Author: B. Sugiyama (bsugiyama@vavestudios.com)
// Date: 2022/10/08
// #######################################################
// 

using System.Net;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Whitelist.Core.SQL {
    public class Query {
        public static JSON.APIJson.Root GetAuthStatus(string customerId, double userId) {
            var jsonData = new JSON.APIJson.Root();

            using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                con.Open();

                var cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_users WHERE UserId = {userId} AND Customer = \"{customerId}\";", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) {
                    if (rdr.HasRows) {
                        if (rdr.GetDouble(2) == userId) {
                            jsonData.Username = rdr.GetString(1);
                            jsonData.AllowedAccess = true;
                        }
                    }
                }

                jsonData.UserId = userId;

                using (var wc = new WebClient()) {
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    string retn = wc.DownloadString("https://api.roblox.com/users/" + userId);

                    JSON.RobloxApi.Root deserialized = JsonConvert.DeserializeObject<JSON.RobloxApi.Root>(retn);

                    jsonData.Username = deserialized.Username;

                    wc.Dispose();
                }

                con.Close();
            }

            return jsonData;
        }
    }
}
