using DietChart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DietChart.Controllers
{
    public class AdminController : AdminBaseController
    {
        // GET: Admin
        public ActionResult AdminDashBoard(Dashboard model)
        {
            DataSet ds = model.GetUserDashboardList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.TotalUser = ds.Tables[0].Rows[0]["TotalUser"].ToString();
            }
            return View(model);
        }
        //[HttpPost]
        //public JsonResult UpdateDietChart(Admin userDetail)
        //{
        //    var profile = Request.Files;
        //    bool status = false;

        //    var datavaluewaking = Request["wakingupdataValue"];
        //    var jsswakingup = new JavaScriptSerializer();
        //    var jdvwakingup = jsswakingup.Deserialize<dynamic>(Request["wakingupdataValue"]);
        //    DataTable dtDietChartOnWakingUpDetails = new DataTable();
        //    dtDietChartOnWakingUpDetails = JsonConvert.DeserializeObject<DataTable>(jdvwakingup["wakingupAddData"]);
        //    userDetail.dtDietChartOnWakingUpDetails = dtDietChartOnWakingUpDetails;

        //    var datavaluebreakfast = Request["BreakfastdataValue"];
        //    var jssBreakfast = new JavaScriptSerializer();
        //    var jdvBreakfast = jssBreakfast.Deserialize<dynamic>(Request["BreakfastdataValue"]);
        //    DataTable dtDietChartBreakfastDetails = new DataTable();
        //    dtDietChartBreakfastDetails = JsonConvert.DeserializeObject<DataTable>(jdvBreakfast["BreakfastAddData"]);
        //    userDetail.dtDietChartBreakfastDetails = dtDietChartBreakfastDetails;

        //    var datavaluemorningsnack = Request["MorningSnackdataValue"];
        //    var jssMorningSnack = new JavaScriptSerializer();
        //    var jdvMorningSnack = jssMorningSnack.Deserialize<dynamic>(Request["MorningSnackdataValue"]);
        //    DataTable dtDietChartMorningSnackDetails = new DataTable();
        //    dtDietChartMorningSnackDetails = JsonConvert.DeserializeObject<DataTable>(jdvMorningSnack["MorningSnackAddData"]);
        //    userDetail.dtDietChartMorningSnackDetails = dtDietChartMorningSnackDetails;

        //    var datavalueLunch = Request["LunchdataValue"];
        //    var jssLunch = new JavaScriptSerializer();
        //    var jdvLunch = jssLunch.Deserialize<dynamic>(Request["LunchdataValue"]);
        //    DataTable dtDietChartLunchDetails = new DataTable();
        //    dtDietChartLunchDetails = JsonConvert.DeserializeObject<DataTable>(jdvLunch["LunchAddData"]);
        //    userDetail.dtDietChartLunchDetails = dtDietChartLunchDetails;

        //    var datavalueEveningSnack = Request["EveningSnackdataValue"];
        //    var jssEveningSnack = new JavaScriptSerializer();
        //    var jdvEveningSnack = jssEveningSnack.Deserialize<dynamic>(Request["EveningSnackdataValue"]);
        //    DataTable dtDietChartEveningSnackDetails = new DataTable();
        //    dtDietChartEveningSnackDetails = JsonConvert.DeserializeObject<DataTable>(jdvEveningSnack["EveningSnackAddData"]);
        //    userDetail.dtDietChartEveningSnackDetails = dtDietChartEveningSnackDetails;

        //    var datavalueDinner = Request["DinnerdataValue"];
        //    var jssDinner = new JavaScriptSerializer();
        //    var jdvDinner = jssDinner.Deserialize<dynamic>(Request["DinnerdataValue"]);
        //    DataTable dtDietChartDinnerDetails = new DataTable();
        //    dtDietChartDinnerDetails = JsonConvert.DeserializeObject<DataTable>(jdvDinner["DinnerAddData"]);
        //    userDetail.dtDietChartDinnerDetails = dtDietChartDinnerDetails;

        //    userDetail.CreatedBy = Session["PK_AdminId"].ToString();
        //    userDetail.Date = string.IsNullOrEmpty(userDetail.Date) ? null : Common.ConvertToSystemDate(userDetail.Date, "dd/MM/yyyy");
        //    DataSet ds = new DataSet();
        //    ds = userDetail.UpdateDietChartDetails();
        //    if (ds != null && ds.Tables[0].Rows.Count > 0)
        //    {
        //        if (ds.Tables[0].Rows[0][0].ToString() == "1")
        //        {
        //            TempData["DietChart"] = "DietChart Details updated successfully";
        //            status = true;
        //        }
        //        else if (ds.Tables[0].Rows[0][0].ToString() == "0")
        //        {
        //            TempData["DietChart"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
        //        }
        //    }
        //    else
        //    {
        //        TempData["DietChart"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
        //    }
        //    return new JsonResult { Data = new { status = status } };
        //}

        public ActionResult DietChartList()
        {
            Admin model = new Admin();
            List<Admin> lst = new List<Admin>();
            DataSet ds = model.GetDietChartList();
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Admin obj = new Admin();
                    obj.Fk_DietChartId = dr["PK_DietChartMasterID"].ToString();
                    obj.Encrypt = Crypto.Encrypt(dr["PK_DietChartMasterID"].ToString());
                    obj.Name = dr["Name"].ToString();
                    obj.Age = dr["Age"].ToString();
                    obj.Weight = dr["Weight"].ToString();
                    obj.Height = dr["Height"].ToString();
                    obj.Date = dr["Date"].ToString();
                    obj.DietPreference = dr["DietPreference"].ToString();
                    obj.BMI = dr["BMI"].ToString();
                    lst.Add(obj);
                }
                model.lstdietchart = lst;
            }
            return View(model);
        }
        public ActionResult PrintDietChartDetails(string Fk_DietChartId)
        {
            Admin model = new Admin();
            if (Fk_DietChartId != null)
            {
                model.Fk_DietChartId = Crypto.Decrypt(Fk_DietChartId);
                List<Admin> lst = new List<Admin>();
                DataSet ds = model.PrintDietChartDetails();
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    ViewBag.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    ViewBag.Age = ds.Tables[0].Rows[0]["Age"].ToString();
                    ViewBag.Weight = ds.Tables[0].Rows[0]["Weight"].ToString();
                    ViewBag.Height = ds.Tables[0].Rows[0]["Height"].ToString();
                    ViewBag.Date = ds.Tables[0].Rows[0]["Date"].ToString();
                    ViewBag.DietPreference = ds.Tables[0].Rows[0]["DietPreference"].ToString();
                    ViewBag.BMI = ds.Tables[0].Rows[0]["BMI"].ToString();

                    foreach (DataRow dr in ds.Tables[1].Rows)
                    {
                        Admin obj = new Admin();
                        obj.OnWakingUp = dr["OnWakingUp"].ToString();
                        lst.Add(obj);
                    }
                    model.lstonwakingup = lst;

                    foreach (DataRow dr in ds.Tables[2].Rows)
                    {
                        Admin obj = new Admin();
                        obj.Breakfast = dr["Breakfast"].ToString();
                        lst.Add(obj);
                    }
                    model.lstbreakfast = lst;

                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        Admin obj = new Admin();
                        obj.MorningSnack = dr["MorningSnack"].ToString();
                        lst.Add(obj);
                    }
                    model.lstmorningsnack = lst;

                    foreach (DataRow dr in ds.Tables[4].Rows)
                    {
                        Admin obj = new Admin();
                        obj.Lunch = dr["Lunch"].ToString();
                        lst.Add(obj);
                    }
                    model.lstlunch = lst;

                    foreach (DataRow dr in ds.Tables[5].Rows)
                    {
                        Admin obj = new Admin();
                        obj.EveningSnack = dr["EveningSnack"].ToString();
                        lst.Add(obj);
                    }
                    model.lsteveningsnack = lst;

                    foreach (DataRow dr in ds.Tables[6].Rows)
                    {
                        Admin obj = new Admin();
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
        public ActionResult DeleteOnWakingUp(string OnWakingUpId)
        {
            Admin model = new Admin();
            model.OnWakingUpId = OnWakingUpId;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteOnWakingUp();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["onwakingup"] = "On Waking Up details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["onwakingup"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["onwakingup"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteBreakfast(string BreakfastID)
        {
            Admin model = new Admin();
            model.BreakfastID = BreakfastID;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteBreakfast();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["Breakfast"] = "Breakfast details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["Breakfast"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["Breakfast"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteMorningSnack(string MorningSnackID)
        {
            Admin model = new Admin();
            model.MorningSnackID = MorningSnackID;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteMorningSnack();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["MorningSnack"] = "Morning Snack details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["MorningSnack"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["MorningSnack"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteLunch(string LunchID)
        {
            Admin model = new Admin();
            model.LunchID = LunchID;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteLunch();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["Lunch"] = "Lunch details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["Lunch"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["Lunch"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteEveningSnack(string EveningSnackID)
        {
            Admin model = new Admin();
            model.EveningSnackID = EveningSnackID;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteEveningSnack();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["EveningSnack"] = "Evening Snack details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["EveningSnack"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["EveningSnack"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteDinner(string DinnerID)
        {
            Admin model = new Admin();
            model.DinnerID = DinnerID;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteDinner();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["Dinner"] = "Dinner details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["Dinner"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["Dinner"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteNote(string NoteId)
        {
            Admin model = new Admin();
            model.NoteId = NoteId;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteNote();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["Note"] = "Note details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["Note"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["Note"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteDietChart(string Id)
        {
            Admin model = new Admin();
            model.Fk_DietChartId = Id;
            model.CreatedBy = Session["PK_AdminId"].ToString();
            DataSet ds = model.DeleteDietChart();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    TempData["msg"] = "Diet Chart details deleted successfully";
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "0")
                {
                    TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                TempData["msg"] = ds.Tables[0].Rows[0]["ErrorMessage"].ToString();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}