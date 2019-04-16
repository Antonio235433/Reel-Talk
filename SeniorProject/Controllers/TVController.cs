using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProject.Controllers
{
    public class TVController : Controller
    {
        // This is an http get function to return the TV search view page.
        [HttpGet]
        public ActionResult SearchTV()
        {
            return View("TVSearch");
        }

        // This is an http get function to return the TV details view page.
        [HttpGet]
        public ActionResult GetTV()
        {
            return View("TV");
        }
    }
}