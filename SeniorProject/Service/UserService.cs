using SeniorProject.DAO;
using SeniorProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeniorProject.Service
{
    public class UserService
    {
        // Pass user model in LoginUser method
        public User LoginUser(User user)
        {
            // create new instance of UserDAO
            UserDAO dataService = new UserDAO();

            // check to see if user is vaild
            if (dataService.ValidUser(user))
            {
                return user;
            }
            else
            {
                return null;
            }

        }

        // Pass user model in UserExists method
        public Boolean UserExists (User user)
        {
            // create new instance of UserDAO
            UserDAO dataService = new UserDAO();
            // check to see if user exists
            if (dataService.UserExists(user))
            {
                return true;
            }

              return false;
        }

        // pass user model in RegisterUser method
        public Boolean RegisterUser(User user)
        {
            // create new instance of UserDAO
            UserDAO dataService = new UserDAO();

            // create new user
            if (dataService.CreateUser(user))
            {
                return true;
            }

            return false;
        }
    }
}