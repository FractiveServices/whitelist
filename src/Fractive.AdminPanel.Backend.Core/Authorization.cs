using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Fractive.AdminPanel.Backend.Core {
    public class Authorization {
        public static bool GetIsAuthorized(string accessToken) {
            using (MySqlConnection con = new MySqlConnection(System.IO.File.ReadAllText("C:\\VAVE_Bin\\Whitelist\\Config\\sqlconnection.txt"))) {
                con.Open();

                var cmd = new MySqlCommand($"SELECT * FROM whitelist.wl_staff WHERE CurrentAccessToken = \"{accessToken}\";", con);

                MySqlDataReader rdr = cmd.ExecuteReader();

                bool allowed = false;

                while (rdr.Read()) {
                    if(rdr.HasRows) {
                        if(rdr.GetString(5) == accessToken) {
                            allowed = true;
                        }
                    }
                }

                con.Close();
                return allowed;
            }
        }
    }
}
