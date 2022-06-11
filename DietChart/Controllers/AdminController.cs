using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DietChart.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult AdminDashBoard()
        {
            return View();
        }

        public ActionResult DietChart()
        {
            return View();
        }

    }
}