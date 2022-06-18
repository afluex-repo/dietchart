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
        public decimal Newuser { get; set; }



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


        public DataSet UpdateDietChartDetails()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@DietChartID",Fk_DietChartId),
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
            DataSet ds = Connection.ExecuteQuery("UpdateDietChart", para);
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

        public DataSet DeleteOnWakingUp()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@OnWakingUpId",OnWakingUpId),
                                      new SqlParameter("@AddedBy",CreatedBy)
                                  };
            DataSet ds = Connection.ExecuteQuery("DeleteOnWakingUp", para);
            return ds;
        }
        public DataSet DeleteBreakfast()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@BreakfastID",BreakfastID),
                                      new SqlParameter("@AddedBy",CreatedBy)
                                  };
            DataSet ds = Connection.ExecuteQuery("DeleteBreakfast", para);
            return ds;
        }
        public DataSet DeleteMorningSnack()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@MorningSnackID",MorningSnackID),
                                      new SqlParameter("@AddedBy",CreatedBy)
                                  };
            DataSet ds = Connection.ExecuteQuery("DeleteMorningSnack", para);
            return ds;
        }
        public DataSet DeleteLunch()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@LunchID",LunchID),
                                      new SqlParameter("@AddedBy",CreatedBy)
                                  };
            DataSet ds = Connection.ExecuteQuery("DeleteLunch", para);
            return ds;
        }
        public DataSet DeleteEveningSnack()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@EveningSnackID",EveningSnackID),
                                      new SqlParameter("@AddedBy",CreatedBy)
                                  };
            DataSet ds = Connection.ExecuteQuery("DeleteEveningSnack", para);
            return ds;
        }
        public DataSet DeleteDinner()
        {
            SqlParameter[] para = {
                                      new SqlParameter("@DinnerID",DinnerID),
                                      new SqlParameter("@AddedBy",CreatedBy)
                                  };
            DataSet ds = Connection.ExecuteQuery("DeleteDinner", para);
            return ds;
        }
    }
}