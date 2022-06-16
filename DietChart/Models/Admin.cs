using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DietChart.Models
{
    public class Admin
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public string Date { get; set; }
        public string DietPreference { get; set; }
        public string BMI { get; set; }
        public DataTable dtDietChartOnWakingUpDetails { get; set; }
        public DataTable dtDietChartBreakfastDetails { get; set; }
        public DataTable dtDietChartMorningSnackDetails { get; set; }
        public DataTable dtDietChartLunchDetails { get; set; }
        public DataTable dtDietChartEveningSnackDetails { get; set; }
        public DataTable dtDietChartDinnerDetails { get; set; }
        public DataTable dtDietChartDetails { get; set; }
        public List<Admin> lstdietchart { get; set; }

        public string OnWakingUp { get; set; }
        public string Breakfast { get; set; }
        public string MorningSnack { get; set; }
        public string Lunch { get; set; }
        public string EveningSnack { get; set; }
        public string Dinner { get; set; }
        public string CreatedBy { get; set; }

        public List<Admin> lstonwakingup { get; set; }
        public List<Admin> lstbreakfast { get; set; }
        public List<Admin> lstmorningsnack { get; set; }
        public List<Admin> lstlunch { get; set; }
        public List<Admin> lsteveningsnack { get; set; }
        public List<Admin> lstdinner { get; set; }
        public string Fk_DietChartId { get; set; }
        public string Encrypt { get; set; }

        public string OnWakingUpId { get; set; }
        public string BreakfastID { get; set; }
        public string MorningSnackID { get; set; }
        public string LunchID { get; set; }
        public string EveningSnackID { get; set; }
        public string DinnerID { get; set; }



        public DataSet SaveDietChartDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Name",Name),
                                       new SqlParameter("@Age", Age),
                                       new SqlParameter("@Weight", Weight),
                                       new SqlParameter("@Height", Height),
                                       new SqlParameter("@Date", Date),
                                       new SqlParameter("@DietPreference", DietPreference),
                                       new SqlParameter("@BMI",BMI),
                                        new SqlParameter("@AddedBy",CreatedBy),
                                      new SqlParameter("@dtDietChartOnWakingUpDetails",dtDietChartOnWakingUpDetails),
                                      new SqlParameter("@dtDietChartBreakfastDetails",dtDietChartBreakfastDetails),
                                      new SqlParameter("@dtDietChartMorningSnackDetails",dtDietChartMorningSnackDetails),
                                      new SqlParameter("@dtDietChartLunchDetails",dtDietChartLunchDetails),
                                      new SqlParameter("@dtDietChartEveningSnackDetails",dtDietChartEveningSnackDetails),
                                      new SqlParameter("@dtDietChartDinnerDetails",dtDietChartDinnerDetails)

                                  };
            DataSet ds = Connection.ExecuteQuery("SaveDietChart", para);
            return ds;
        }
        public DataSet GetDietChartList()
        {
            DataSet ds = Connection.ExecuteQuery("GetDietChartList");
            return ds;
        }
        
        public DataSet PrintDietChartDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@Fk_DietChartId",Fk_DietChartId)
                                  };
            DataSet ds = Connection.ExecuteQuery("PrintDietChartDetails", para);
            return ds;
        }
        public DataSet GetDietChartDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@PK_DietChartId",Fk_DietChartId)
                                  };
            DataSet ds = Connection.ExecuteQuery("GetDietChartDetails", para);
            return ds;
        }

      

    }
}