using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Whitelist.Server {
    internal class Program {
        public static HttpListener listener;

        //public static string url = "http://127.0.0.1:80/";

        static void Main(string[] args) {
            string url = $"http://{args[0]}:80/";

            Logging.Logger.Initialize();

            // Create a Http server and start listening for incoming connections
            listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();
            Console.WriteLine("Listening for connections on {0}", url);

            // Handle requests
            Task listenTask = ASTaskHandler.HandleIncomingConnections(listener);
            listenTask.GetAwaiter().GetResult();

            // Close the listener
            listener.Close();
        }
    }
}
