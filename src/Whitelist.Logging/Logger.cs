// #######################################################
// Copyright (c) VAVE 2022. All rights reserved.
// VAVE CONFIDENTIAL AND PROPRIETARY
// 
// File: Logger.cs
// Description: Logging system for Whitelist backend
// 
// Author: B. Sugiyama (bsugiyama@vavestudios.com)
// Date: 2022/10/08
// #######################################################
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Whitelist.Logging {
    public class Logger {
        public static string logPath = "C:\\VAVE_Host\\Logs\\Whitelist" + $@"\logs\server_{"prod"}_{DateTime.Today.ToString("yyyy-MM-dd")}.log";

        private static void WriteLog(string message) {
            try {
                using (var writetext = File.AppendText(logPath)) {
                    writetext.WriteLine(message);
                }
            }
            catch (Exception ex) {
                Console.Write(ex.ToString());
            }
        }

        public static void Initialize() {
            if (!File.Exists(logPath)) {
                File.Create(logPath).Close();
                //File.WriteAllText(logPath, "");
            }

            WriteLog("########## Whitelist Log ##########");
            WriteLog("Server: " + Environment.MachineName);
            WriteLog("IP: " + "IP LOOKUP NOT IMPLEMENTED");
            WriteLog("Log created: " + DateTime.Today.ToString("yyyy-MM-dd")); 
            WriteLog("##################################");
            WriteLog("");
        }

        public static void WriteToLog(string message) {
            string outTxt = $"[{DateTime.Now.ToShortTimeString()}] - {message}";

            WriteLog(outTxt);
        }
    }
}
