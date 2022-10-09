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

using System;
using System.Net;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Whitelist.Core.Discord;

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

                try {
                    using (var wc = new WebClient()) {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        string retn = wc.DownloadString("https://api.roblox.com/users/" + userId);

                        JSON.RobloxApi.Root deserialized = JsonConvert.DeserializeObject<JSON.RobloxApi.Root>(retn);

                        jsonData.Username = deserialized.Username;

                        wc.Dispose();
                    }
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.ToString());
                    Logging.Logger.WriteToLog(ex.ToString());
                }

                con.Close();
            }

            return jsonData;
        }

        public static string GetCustomerIdFromDiscordId(long discordId) {
            string customerId = "";

            using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                con.Open();

                var cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_customers WHERE DiscordId = {discordId};", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) {
                    if (rdr.HasRows) {
                        if (rdr.GetDouble(2) == discordId) {
                            customerId = rdr.GetString(4);
                        }
                        else {
                            return "";
                        }
                    }
                    else {
                        return "";
                    }
                }

                con.Close();
            }

            return customerId;
        }

        public static int GetLatestDbEntryId() {
            int highest = 0;

            using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                con.Open();

                var cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_users WHERE ID IN (SELECT Max(ID) FROM whitelist.wl_users);", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) {
                    highest = rdr.GetInt16(0);
                }

                con.Close();
            }

            return highest;
        }
    }
}
