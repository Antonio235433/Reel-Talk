using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorProject.Models
{
    // Model class for searching reviews
    public class SearchReview
    {
        [Required(ErrorMessage = "Input is required.")]
        [MinLength(1, ErrorMessage = "Minimum length for input is one characters.")]
        [MaxLength(50, ErrorMessage = "Max length for input is 50 characters.")]
        public string Title { get; set; }
    }
}