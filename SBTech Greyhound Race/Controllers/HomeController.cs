using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SBTech_Greyhound_Race.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult GreyHoundRace()
        {
            ViewBag.Title = "Grey Hound Race Events";
            return View();
        }
    }
}
