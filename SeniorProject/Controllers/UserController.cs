using SeniorProject.Models;
using SeniorProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProject.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        
        //This http get method returns the login view page.
        [HttpGet]
        public ActionResult Login()
        {
            return View("Login");
        }

        //This http get method returns the register view page.
        [HttpGet]
        public ActionResult Register()
        {
            return View("Register");
        }

       //This is an http post method that returns the movie search page after user logs in.
       //Pass the user model in DoLogin method
        [HttpPost]
        public ActionResult DoLogin(User user)
        {
            {
                //create a new instance of UserService class 
                UserService us = new UserService();

                //check to see if user is null
                User usermodel = us.LoginUser(user);

                if (usermodel != null)
                {
                    //if not null return succcess and return view
                    ViewData["LoginResponse"] = "Successful Login";
                    Session["user"] = usermodel;
               
                }

                else
                {
                    //if null return error and redirect back to login view page
                    ViewData["LoginResponse"] = "Incorrect username and password";

                    return View("login");

                }
            }
            //return home page
           return View("~/Views/Home/Home.cshtml");
        }
        //This is an http post method that returns the login view page after user registers.
        //Pass the user model in DoRegister method
        [HttpPost]
        public ActionResult DoRegister(User user)
        {
            {
                // create a new instance of UserService class 
                UserService us = new UserService();

                if (us.UserExists(user) == false)
                {
                    // check to see if RegisterUser method equals true
                    if (us.RegisterUser(user) == true)
                    {
                        // if true return success message and redirect user to login view page
                        ViewData["RegisterReponse"] = "You have created a new account";
                    }
                    else
                    {
                        ViewData["RegisterResponse"] = "Username is already taken!";
                    }
                }

                else
                {
                    // if false return error message and redirect user back register view page
                    ViewData["RegisterResponse"] = "Username is already taken!";

                    // return user to register page
                    return View("Register");
                }

            }
            // return login view page after succesful user registration. 
            return View("login");
        }
        [HttpGet]
        public ActionResult Logout()
        {
            // remove all keys and values
            Session.Clear();
            // return user back to login view page.
            return View("login");

        }
    }
}