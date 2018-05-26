using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gearproj.Models;

namespace gearproj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            ApplicationDbContext adb = new ApplicationDbContext();
            
            return View();
        }
    }
}
