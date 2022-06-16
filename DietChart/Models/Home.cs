using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DietChart.Models
{
    public class Home
    {
        public string LoginId { get; set; }
        public string Password { get; set; }

        public DataSet Login()
        {
            SqlParameter[] para =
            {
                new SqlParameter("@LoginId",LoginId),
                new SqlParameter("@Password",Password)
            };
            DataSet ds = Connection.ExecuteQuery("Login", para);
            return ds;
        }
        

    }
}