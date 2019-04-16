using SeniorProject.Models;
using SeniorProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SeniorProject.Controllers
{
    public class ReviewController : Controller
    {

        // This is a http Get function to return the Review view page.
        [HttpGet]
        public ActionResult Review()
        {
            return View("Review");
        }
        
        [HttpGet]
        public ActionResult CreateReview()
        {
            //return the CreateReview page.
            return View("CreateReview");
        }

       
       
        [HttpGet]
        public ActionResult MyReview()
        {
            //Create an instance of the ReviewService class. 
            ReviewService reviewService = new ReviewService();

            //Return the MyReview view page, passing through the GetReviews method, User model and session for the user id.
            return View("MyReview", reviewService.GetReviews(((User)Session["user"]).UserID));
        }
        
        [HttpGet]
        public ActionResult EditReview()
        {
            //Create int variable and parsed query string to integer
            int reviewId = int.Parse(Request.QueryString["id"]);
            //Create an instance of the ReviewService class. 
            ReviewService reviewService = new ReviewService();
            //Return the EditReview view page, passing through the GetReview method with reviewId parameter.
            return View("EditReview", reviewService.GetReview(reviewId));

        }
       
        [HttpPost]
        public ActionResult SearchReview(SearchReview search)

        {
            //Create an instance of the ReviewService class. 
            ReviewService reviewService = new ReviewService();
            //Return the SearchReview view page, passing through the SerchReview method and search parameter.
            return View("SearchReview", reviewService.SearchReviews(search.Title));
        }
   
      
        [HttpPost]
        public ActionResult DoEditReview(Review review)
        {
            //Create an instance of the ReviewService class. 
            ReviewService reviewService = new ReviewService();

            // Call EditReview method
            reviewService.EditReview(review);

            //Return user back to MyReview page after request.
            return RedirectToAction("MyReview");
        }

        [HttpGet]
        public ActionResult DeleteReview()

        {
            //Create int variable and parsed query string to integer
            int reviewId = int.Parse(Request.QueryString["id"]);
            //Create an instance of the ReviewService class. 
            ReviewService reviewService = new ReviewService();

            // Call DeleteReview method
            reviewService.DeleteReview(reviewId);

            // Return user back to MyReview page.
            return RedirectToAction("MyReview");

        }
        [HttpPost]
        public ActionResult CreateReview(Review review)
        {
            //Create an instance of the ReviewService class. 
            ReviewService reviewService = new ReviewService();

            // Owner_Id of the review being created equals to UserId, which is retrieved from the session.
            review.Owner_ID = ((User)Session["user"]).UserID;

            // if method does not equal null redirect user to Myreview page.
            if (reviewService.CreateReview(review) != null)
            {
                return View("CreateReview");
            }
            // if else return CreateReview page
            else
            {
                return View("CreateReview");
            }
        }

    }
}