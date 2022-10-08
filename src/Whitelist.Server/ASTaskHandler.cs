// #######################################################
// Copyright (c) VAVE 2022. All rights reserved.
// VAVE CONFIDENTIAL AND PROPRIETARY
// 
// File: ASTaskHandler.cs
// Description: Task handler for the server software for Whitelist backend
// 
// Author: B. Sugiyama (bsugiyama@vavestudios.com)
// Date: 2022/10/08
// #######################################################
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Server {
    internal class ASTaskHandler {
        public static int requestCount = 0;

        public static async Task HandleIncomingConnections(HttpListener listener) {
            bool runServer = true;

            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer) {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener.GetContextAsync();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                // Print out some info about the request
                Console.WriteLine("Request #: {0}", ++requestCount);
                Console.WriteLine(req.Url.ToString());
                Console.WriteLine(req.HttpMethod);
                Console.WriteLine(req.UserHostName);
                Console.WriteLine(req.UserAgent);
                Console.WriteLine();

                Logging.Logger.WriteToLog("Request #: " + requestCount);
                Logging.Logger.WriteToLog("Requested URI: " + req.Url.ToString());
                Logging.Logger.WriteToLog("Request Method: " + req.HttpMethod);
                Logging.Logger.WriteToLog("Request Host: " + req.UserHostName);
                Logging.Logger.WriteToLog("Request Useragent: " + req.UserAgent);
                Logging.Logger.WriteToLog("");

                if (req.Url.AbsolutePath.Contains("/whitelist")) {
                    string uri = ctx.Request.Url.AbsoluteUri;
                    string rsp = DataHandler.GetResponse(uri);

                    // Write the response info
                    string disableSubmit = !runServer ? "disabled" : "";
                    byte[] data = Encoding.UTF8.GetBytes(rsp);
                    resp.ContentType = "application/json";
                    resp.ContentEncoding = Encoding.UTF8;
                    resp.ContentLength64 = data.LongLength;

                    // Write out to the response stream (asynchronously), then close it
                    await resp.OutputStream.WriteAsync(data, 0, data.Length);
                    resp.Close();
                }
                else {
                    // Write the response info
                    string disableSubmit = !runServer ? "disabled" : "";
                    byte[] data = Encoding.UTF8.GetBytes("{\"Error\": \"Access denied.\"}");
                    resp.ContentType = "application/json";
                    resp.ContentEncoding = Encoding.UTF8;
                    resp.ContentLength64 = data.LongLength;

                    // Write out to the response stream (asynchronously), then close it
                    await resp.OutputStream.WriteAsync(data, 0, data.Length);
                    resp.Close();
                }
            }
        }
    }
}
