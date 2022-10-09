// #######################################################
// Copyright (c) VAVE 2022. All rights reserved.
// VAVE CONFIDENTIAL AND PROPRIETARY
// 
// File: Alter.cs
// Description: SQL updating manager
// 
// Author: B. Sugiyama (bsugiyama@vavestudios.com)
// Date: 2022/10/08
// #######################################################
// 

using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Core.SQL {
    public class Alter {
        public static void AddUserToWhitelist(string customerId, string userId) {
            using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                con.Open();

                string username = "";

                int dbEntryId = Query.GetLatestDbEntryId() + 1;

                try {
                    using (var wc = new WebClient()) {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        string retn = wc.DownloadString("https://api.roblox.com/users/" + userId);

                        JSON.RobloxApi.Root deserialized = JsonConvert.DeserializeObject<JSON.RobloxApi.Root>(retn);

                        username = deserialized.Username;
                        wc.Dispose();
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                    Logging.Logger.WriteToLog(ex.ToString());
                }

                var cmd = new MySqlCommand($"INSERT INTO `whitelist`.`wl_users` (`ID`, `Username`, `UserID`, `Customer`) VALUES ('{dbEntryId}', '{username}', '{userId}', '{customerId}');", con);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }

        public static void RemoveUserFromWhitelist(string userId) {
            using (MySqlConnection con = new MySqlConnection(Connection.GetConnectionString())) {
                con.Open();

                int dbEntryId = Query.GetLatestDbEntryId() + 1;

                var cmd = new MySqlCommand($"DELETE FROM `whitelist`.`wl_users` WHERE (`UserID` = '{userId}');", con);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                con.Close();
            }
        }
    }
}
