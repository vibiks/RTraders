using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RTraders.Models
{
    public class DBoperations
    {
        private string strConnectionString = ConfigurationManager.ConnectionStrings["mysqlconnection"].ConnectionString;
        public int authenticateuser(string username, string pwd)
        {
            using (MySqlConnection con = new MySqlConnection(strConnectionString))
            {
                try
                {
                    string SQLvalidate = "select userid from tbluserinfo where username = @username and userpassword=@pwd";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    cmd.Connection = con;
                    cmd.CommandText = SQLvalidate;
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt32(0);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                }
                catch (MySql.Data.MySqlClient.MySqlException ex)
                {
                    return -1;
                }
                finally
                {
                    con.Close();
                }
            }
        }
    }
}