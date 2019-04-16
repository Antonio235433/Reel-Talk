using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProject.Controllers
{
    public class MovieController : Controller
    {
        
        // This is a http Get function to return the movie search view page after the user searches for a movie. 
        [HttpGet]
        public ActionResult SearchMovie()
        {
            return View("MovieSearch");
        }
        // This is a http Get function to return the get movie details view page after user clicks movie details
        [HttpGet]
        public ActionResult GetMovie()
        {
            return View("Movie");
        }
    }
}