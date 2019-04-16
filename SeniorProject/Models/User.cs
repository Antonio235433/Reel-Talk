using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorProject.Models
{
    // Model class for User
    public class User
    {
        // variables for user 
        [Required(ErrorMessage = "User name is required.")]
        [StringLength(24, ErrorMessage = "Maxium length for Username is 24 Characters.")]
        [MinLength(3, ErrorMessage = "Minimum length for Username is 3 Characters.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [StringLength(14, ErrorMessage = "Maxium length for Password is 14 Characters.")]
        [MinLength(8, ErrorMessage = "Minimum length for Password is 8 Characters.")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public int UserID { get; set; }
    }
}