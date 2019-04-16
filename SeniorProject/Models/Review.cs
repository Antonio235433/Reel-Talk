using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeniorProject.Models
{
    // Review model class
    public class Review
    {
        // variables for review
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(215, ErrorMessage = "Maxium length for title is 215 Characters.")]
        [MinLength(1, ErrorMessage = "Minimum length for title is 1 Character.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Content is required.")]
        [MinLength(3, ErrorMessage = "Minimum length for content is 3 Characters.")]
        [MaxLength(500, ErrorMessage = "Max length for content is 500 Characters.")]
        public string Content { get; set; }
        public int Owner_ID { get; set; }
        public int id { get; set; }
     
      
    }
}