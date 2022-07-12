using DietChart.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace DietChart.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Login()
        {
            Session.Abandon();
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login(Home model)
        {
            string FormName = "";
            string Controller = "";
            try
            {
                DataSet ds = model.Login();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["msg"].ToString() == "1")
                    {
                        if (ds.Tables[0].Rows[0]["UserType"].ToString() == "Admin")
                        {
                            Session["PK_AdminId"] = ds.Tables[0].Rows[0]["PK_AdminId"].ToString();
                            Session["LoginId"] = ds.Tables[0].Rows[0]["LoginId"].ToString();
                            Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                            Session["Name"] = ds.Tables[0].Rows[0]["Name"].ToString();
                            Session["Email"] = ds.Tables[0].Rows[0]["Email"].ToString();
                            Session["ProfilePic"] = ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                            FormName = "AdminDashBoard";
                            Controller = "Admin";
                        }
                        else
                        {
                            TempData["msg"] = "Incorect LoginId Or Password";
                            FormName = "Login";
                            Controller = "Home";
                        }
                    }
                    else
                    {
                        TempData["msg"] = "Incorect LoginId Or Password";
                        FormName = "Login";
                        Controller = "Home";
                    }
                }
                else
                {

                    TempData["msg"] = "Incorect LoginId Or Password";
                    FormName = "Login";
                    Controller = "Home";
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                FormName = "Login";
                Controller = "Home";
            }
            return RedirectToAction(FormName, Controller);
        }
        public ActionResult DietChart(string Fk_DietChartId, string Newid)
        {
            Admin model = new Admin();
            if (Fk_DietChartId != null)
            {
                List<Admin> lst = new List<Admin>();
                model.Fk_DietChartId = Fk_DietChartId;
                model.Newuser = Convert.ToDecimal(Newid);
                DataSet ds = model.PrintDietChartDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    model.Age = ds.Tables[0].Rows[0]["Age"].ToString();
                    model.Weight = ds.Tables[0].Rows[0]["Weight"].ToString();
                    model.Height = ds.Tables[0].Rows[0]["Height"].ToString();
                    model.Date = ds.Tables[0].Rows[0]["Date"].ToString();
                    model.DietPreference = ds.Tables[0].Rows[0]["DietPreference"].ToString();
                    model.BMI = ds.Tables[0].Rows[0]["BMI"].ToString();
                    model.Calorie = ds.Tables[0].Rows[0]["Calorie"].ToString();
                    model.Protein = ds.Tables[0].Rows[0]["Protein"].ToString();
                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        Admin obj = new Admin();
                        obj.OnWakingUpId = dr["PK_OnWakingUpId"].ToString();
                        obj.OnWakingUp = dr["OnWakingUp"].ToString();
                        lst.Add(obj);
                    }
                    model.lstonwakingup = lst;

                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        Admin obj = new Admin();
                        obj.BreakfastID = dr["PK_BreakfastID"].ToString();
                        obj.Breakfast = dr["Breakfast"].ToString();
                        lst.Add(obj);
                    }
                    model.lstbreakfast = lst;

                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        Admin obj = new Admin();
                        obj.MorningSnackID = dr["PK_MorningSnackID"].ToString();
                        obj.MorningSnack = dr["MorningSnack"].ToString();
                        lst.Add(obj);
                    }
                    model.lstmorningsnack = lst;

                    foreach (DataRow dr in ds.Tables[4].Rows)
                    {
                        Admin obj = new Admin();
                        obj.LunchID = dr["PK_LunchID"].ToString();
                        obj.Lunch = dr["Lunch"].ToString();
                        lst.Add(obj);
                    }
                    model.lstlunch = lst;

                    foreach (DataRow dr in ds.Tables[5].Rows)
                    {
                        Admin obj = new Admin();
                        obj.EveningSnackID = dr["PK_EveningSnackID"].ToString();
                        obj.EveningSnack = dr["EveningSnack"].ToString();
                        lst.Add(obj);
                    }
                    model.lsteveningsnack = lst;

                    foreach (DataRow dr in ds.Tables[6].Rows)
                    {
                        Admin obj = new Admin();
                        obj.DinnerID = dr["PK_DinnerID"].ToString();
                        obj.Dinner = dr["Dinner"].ToString();
                        lst.Add(obj);
                    }
                    model.lstdinner = lst;

                    foreach (DataRow dr in ds.Tables[7].Rows)
                    {
                        Admin obj = new Admin();
                        obj.NoteId = dr["PK_NoteID"].ToString();
                        obj.Note = dr["Note"].ToString();
                        lst.Add(obj);
                    }
                    model.lstNote = lst;
                }
            }
            return View(model);
        }
        [HttpPost]
        public JsonResult SaveDietChart(Admin userDetail)
        {
            var profile = Request.Files;
            bool status = false;
            var datavaluewaking = Request["wakingupdataValue"];
            var jsswakingup = new JavaScriptSerializer();
            var jdvwakingup = jsswakingup.Deserialize<dynamic>(Request["wakingupdataValue"]);
            DataTable dtDietChartOnWakingUpDetails = new DataTable();
            var datavaluebreakfast = Request["BreakfastdataValue"];
            var jssBreakfast = new JavaScriptSerializer();
            var jdvBreakfast = jssBreakfast.Deserialize<dynamic>(Request["BreakfastdataValue"]);
            DataTable dtDietChartBreakfastDetails = new DataTable();
            var datavaluemorningsnack = Request["MorningSnackdataValue"];
            var jssMorningSnack = new JavaScriptSerializer();
            var jdvMorningSnack = jssMorningSnack.Deserialize<dynamic>(Request["MorningSnackdataValue"]);
            DataTable dtDietChartMorningSnackDetails = new DataTable();
            var datavalueLunch = Request["LunchdataValue"];
            var jssLunch = new JavaScriptSerializer();
            var jdvLunch = jssLunch.Deserialize<dynamic>(Request["LunchdataValue"]);
            DataTable dtDietChartLunchDetails = new DataTable();
            var datavalueEveningSnack = Request["EveningSnackdataValue"];
            var jssEveningSnack = new JavaScriptSerializer();
            var jdvEveningSnack = jssEveningSnack.Deserialize<dynamic>(Request["EveningSnackdataValue"]);
            DataTable dtDietChartEveningSnackDetails = new DataTable();
            var datavalueDinner = Request["DinnerdataValue"];
            var jssDinner = new JavaScriptSerializer();
            var jdvDinner = jssDinner.Deserialize<dynamic>(Request["DinnerdataValue"]);
            DataTable dtDietChartDinnerDetails = new DataTable();
            var datavalueNote = Request["NotedataValue"];
            var jssNote = new JavaScriptSerializer();
            var jdvNote = jssNote.Deserialize<dynamic>(Request["NotedataValue"]);
            DataTable dtDietChartNoteDetails = new DataTable();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            dtDietChartOnWakingUpDetails.Columns.Add("OnWakingUp", typeof(string));
            dtDietChartBreakfastDetails.Columns.Add("Breakfast", typeof(string));
            dtDietChartMorningSnackDetails.Columns.Add("MorningSnack", typeof(string));
            dtDietChartLunchDetails.Columns.Add("Lunch", typeof(string));
            dtDietChartEveningSnackDetails.Columns.Add("EveningSnack", typeof(string));
            dtDietChartDinnerDetails.Columns.Add("Dinner", typeof(string));
            dtDietChartNoteDetails.Columns.Add("Note", typeof(string));
            dt = JsonConvert.DeserializeObject<DataTable>(jdvwakingup["wakingupAddData"]);
            dt1 = JsonConvert.DeserializeObject<DataTable>(jdvBreakfast["BreakfastAddData"]);
            dt2 = JsonConvert.DeserializeObject<DataTable>(jdvMorningSnack["MorningSnackAddData"]);
            dt3 = JsonConvert.DeserializeObject<DataTable>(jdvLunch["LunchAddData"]);
            dt4 = JsonConvert.DeserializeObject<DataTable>(jdvEveningSnack["EveningSnackAddData"]);
            dt5 = JsonConvert.DeserializeObject<DataTable>(jdvDinner["DinnerAddData"]);
            dt6 = JsonConvert.DeserializeObject<DataTable>(jdvNote["NoteAddData"]);

            foreach (DataRow row in dt.Rows)
            {
                var OnWakingUp = row["OnWakingUp"].ToString();
                dtDietChartOnWakingUpDetails.Rows.Add(OnWakingUp);
            }
            foreach (DataRow row in dt1.Rows)
            {
                var Breakfast = row["Breakfast"].ToString();
                dtDietChartBreakfastDetails.Rows.Add(Breakfast);
            }
            foreach (DataRow row in dt2.Rows)
            {
                var MorningSnack = row["MorningSnack"].ToString();
                dtDietChartMorningSnackDetails.Rows.Add(MorningSnack);
            }
            foreach (DataRow row in dt3.Rows)
            {
                var Lunch = row["Lunch"].ToString();
                dtDietChartLunchDetails.Rows.Add(Lunch);
            }
            foreach (DataRow row in dt4.Rows)
            {
                var EveningSnack = row["EveningSnack"].ToString();
                dtDietChartEveningSnackDetails.Rows.Add(EveningSnack);
            }
            foreach (DataRow row in dt5.Rows)
            {
                var Dinner = row["Dinner"].ToString();
                dtDietChartDinnerDetails.Rows.Add(Dinner);
            }
            foreach (DataRow row in dt6.Rows)
            {
                var Note = row["Note"].ToString();
                dtDietChartNoteDetails.Rows.Add(Note);
            }
            userDetail.dtDietChartOnWakingUpDetails = dtDietChartOnWakingUpDetails;
            userDetail.dtDietChartBreakfastDetails = dtDietChartBreakfastDetails;
            userDetail.dtDietChartMorningSnackDetails = dtDietChartMorningSnackDetails;
            userDetail.dtDietChartLunchDetails = dtDietChartLunchDetails;
            userDetail.dtDietChartEveningSnackDetails = dtDietChartEveningSnackDetails;
            userDetail.dtDietChartDinnerDetails = dtDietChartDinnerDetails;
            userDetail.dtDietChartNoteDetails = dtDietChartNoteDetails;
            userDetail.CreatedBy = "1";
            userDetail.Date = string.IsNullOrEmpty(userDetail.Date) ? null : Common.ConvertToSystemDate(userDetail.Date, "dd/MM/yyyy");
            DataSet ds = new DataSet();
            ds = userDetail.SaveDietChartDetails();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["DietChart"] = "Diet Chart Details saved successfully";
                    status = true;
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["DietChart"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["DietChart"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}