using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAPIDatabase.Controllers
{
    public class DBHelper
    {

        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Dbconnection"].ConnectionString;
        }


        public string  getSp(int id)
        {
            SqlConnection myConnection = new SqlConnection(GetConnectionString());
            SqlCommand cmd = new SqlCommand("Get_Employee", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            myConnection.Open();

            SqlParameter custId = cmd.Parameters.AddWithValue("@userId", 1);
           

            //SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);


            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                   return dr["FirstName"].ToString() + ' ' +
                    dr["LastName"].ToString() + ' ' +
                    dr[3].ToString() + ' ' +
                    dr["Email"].ToString();
                }
            }

            return "Fasle";

        }

    }
}