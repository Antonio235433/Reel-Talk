using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProject.Controllers
{
    public class HomeController : Controller
    {
    // This contoller only inteacts with the Home view page to display the page...there is no model for this contoller.
        public ActionResult Home()
        {
            return View("Home");
        }
    }
}