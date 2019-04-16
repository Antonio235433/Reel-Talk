using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeniorProject.Models
{
    // Extends the Review model
    public class ReviewWithUsername : Review
    {
        public string Username { get; set; }
    }
}
