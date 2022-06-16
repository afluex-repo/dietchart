using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace DietChart.Models
{
    public class Dashboard
    {

        public DataSet GetUserDashboardList()
        {
            DataSet ds = Connection.ExecuteQuery("GetUserDashboardList");
            return ds;
        }
    }
}