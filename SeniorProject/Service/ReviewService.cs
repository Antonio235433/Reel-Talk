using SeniorProject.DAO;
using SeniorProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeniorProject.Service
{
    public class ReviewService
    {
        // pass user model in RegisterUser method
        public Review CreateReview(Review review)
        {
            // create new instance of ReviewDAO
            ReviewDAO dataService = new ReviewDAO();


            if (dataService.CreateReview(review))
            {
                return review;
            }
            else
            {
                return null;
            }
        }

        public List<ReviewWithUsername> SearchReviews(string title)
        {
            // create new instance of ReviewDAO
            ReviewDAO dataService = new ReviewDAO();

            return dataService.SearchReviews(title);
        }

        public List<Review> GetReviews(int userid)
        {
            // create new instance of ReviewDAO
            ReviewDAO dataService = new ReviewDAO();

            // return GetReviews method
            return dataService.GetReviews(userid);
        }

        public Review GetReview(int reviewid)
        {
            // create new instance of ReviewDAO
            ReviewDAO dataService = new ReviewDAO();
            // create GetReview method
            return dataService.GetReview(reviewid);

        }

        public bool EditReview(Review review)
        {
            // create new instance of ReviewDAO
            ReviewDAO dataService = new ReviewDAO();


            if (dataService.UpdateReview(review))
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool DeleteReview(int reviewId)
        {
            // create new instance of ReviewDAO
            ReviewDAO dataService = new ReviewDAO();


            if (dataService.DeleteReview(reviewId))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}