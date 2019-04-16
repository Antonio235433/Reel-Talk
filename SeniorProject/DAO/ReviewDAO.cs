using SeniorProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SeniorProject.DAO
{
    public class ReviewDAO
    {
        public bool CreateReview(Review review)
        {
            bool result = false;

            try
            {
                // Setup INSERT query with parameters
                string query = "INSERT INTO dbo.Review (TITLE, CONTENT, OWNER_ID) " +
                    "VALUES (@Title, @Content, @Owner_ID)";

                // Create connection to cloud DB and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 215).Value = review.Title;
                    cmd.Parameters.Add("@Content", SqlDbType.Text).Value = review.Content;
                    cmd.Parameters.Add("@Owner_ID", SqlDbType.Int, 11).Value = review.Owner_ID;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of create
            return result;
        }

        public List<Review> GetReviews(int userID)
        {
            List<Review> review = new List<Review>();

            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Review WHERE OWNER_ID=@userid";

                // Create connection to cloud DB and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userID;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int value1 = reader.GetInt32(0);
                        string value2 = reader.GetString(1);
                        string value3 = reader.GetString(2);
                        int value4 = reader.GetInt32(3);


                        Review R = new Review();

                        R.id = value1;
                        R.Title = value2;
                        R.Content = value3;
                        R.Owner_ID = value4;

                        review.Add(R);
                    }

                    // Close the connection
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of review
            return review;
        }
        public bool UpdateReview(Review review)
        {
            bool result = false;

            try
            {
                // Setup UPDATE query with parameters
                string query = "UPDATE dbo.Review SET TITLE=@Title, CONTENT=@Content WHERE Id=@id";

                // Create connection to cloud DB and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@Title", SqlDbType.VarChar, 215).Value = review.Title;
                    cmd.Parameters.Add("@Content", SqlDbType.Text).Value = review.Content;
                    cmd.Parameters.Add("@id", SqlDbType.Int, 11).Value = review.id;

                    // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of result
            return result;
        }
        public Review GetReview(int reviewID)
        {
            Review review = new Review();

            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Review WHERE Id=@reviewid";

                // Create connection to cloud DB and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@reviewid", SqlDbType.Int).Value = reviewID;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            int value1 = reader.GetInt32(0);
                            string value2 = reader.GetString(1);
                            string value3 = reader.GetString(2);
                            int value4 = reader.GetInt32(3);

                            Review R = new Review();

                            R.id = value1;
                            R.Title = value2;
                            R.Content = value3;
                            R.Owner_ID = value4;

                            review = R;
                        }
                    }

                    // Close the connection
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of review
            return review;
        }
        public bool DeleteReview(int reviewID)
        {
            bool result = false;

            try
            {
                // Setup DELTE query with parameters
                string query = "DELETE FROM dbo.Review WHERE Id=@id";


                // Create connection to cloud DB and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = reviewID;
                    
               // Open the connection, execute INSERT, and close the connection
                    cn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows == 1)
                        result = true;
                    else
                        result = false;
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of create
            return result;
        }
        public List<ReviewWithUsername> SearchReviews(string title)
        {
            List<ReviewWithUsername> review = new List<ReviewWithUsername>();

            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Review INNER JOIN dbo.Account ON dbo.Review.OWNER_ID = dbo.Account.Id WHERE dbo.Review.TITLE like @abc";

                // Create connection to cloud DB and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.AddWithValue("@abc", "%" + title + "%");

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        int value1 = reader.GetInt32(0);
                        string value2 = reader.GetString(1);
                        string value3 = reader.GetString(2);
                        int value4 = reader.GetInt32(3);
                        string value5 = reader.GetString(5);

            

                        ReviewWithUsername R = new ReviewWithUsername();

                        R.id = value1;
                        R.Title = value2;
                        R.Content = value3;
                        R.Owner_ID = value4;
                        R.Username = value5;

                        review.Add(R);
                    }

                    // Close the connection
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result of review
            return review;
        }

    }

}