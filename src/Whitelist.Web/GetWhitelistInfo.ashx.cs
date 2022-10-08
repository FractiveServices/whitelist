// #######################################################
// Copyright (c) VAVE 2022. All rights reserved.
// VAVE CONFIDENTIAL AND PROPRIETARY
// 
// File: GetWhitelistInfo.ashx.cs
// Description: Exposed API endpoint for getting whitelist info
// 
// Author: B. Sugiyama (bsugiyama@vavestudios.com)
// Date: 2022/10/08
// #######################################################
// 

using Newtonsoft.Json;
using System.Linq;
using System.Web;

namespace Whitelist.Web {
    /// <summary>
    /// Summary description for GetWhitelistInfo
    /// </summary>
    public class GetWhitelistInfo : IHttpHandler {

        public void ProcessRequest(HttpContext context) {
            context.Response.ContentType = "application/json";

            string end = context.Request.Url.AbsoluteUri.Split('/').Last();

            var deserializedReq = JsonConvert.DeserializeObject<Core.JSON.Request.Root>(Core.Encode.Base64.Decode(end));

            var data = Core.SQL.Query.GetAuthStatus(deserializedReq.Customer, deserializedReq.ID);

            string output = JsonConvert.SerializeObject(data);

            context.Response.Write(output);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }
    }
}