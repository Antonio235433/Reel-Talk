using SeniorProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SeniorProject.DAO
{
    public class UserDAO
    {
        public bool CreateUser(User user)
        {
            bool result = false;

            try
            {
                // Setup INSERT query with parameters
                string query = "INSERT INTO dbo.Account (USER_NAME, PASSWORD) " +
                    "VALUES (@UserName, @Password)";

                // Create connection to cloud DB and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 24).Value = user.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 14).Value = user.Password;



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
        public bool UserExists(User user)
        {
            bool result = false;

            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Account WHERE USER_NAME=@UserName";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 24).Value = user.UserName;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                        result = true;
                    else
                        result = false;

                    // Close the connection
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result
            return result;
        }
        public Boolean ValidUser(User user)
        {
            bool result = false;

            try
            {
                // Setup SELECT query with parameters
                string query = "SELECT * FROM dbo.Account WHERE USER_NAME=@UserName AND PASSWORD=@Password";

                // Create connection and command
                using (SqlConnection cn = new SqlConnection("Server=tcp:reeltalkdb.database.windows.net,1433;Initial Catalog=ReelTalkDB;Persist Security Info=False;User ID=antonio23;Password=Password23!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    // Set query parameters and their values
                    cmd.Parameters.Add("@UserName", SqlDbType.VarChar, 24).Value = user.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 14).Value = user.Password;

                    // Open the connection
                    cn.Open();

                    // Using a DataReader see if query returns any rows
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        result = true;
                        while (reader.Read())
                        {
                            int ID = int.Parse(reader["ID"].ToString());
                            user.UserID = ID;
                        }
                    }
                    else
                        result = false;

                    // Close the connection
                    cn.Close();
                }

            }
            catch (SqlException e)
            {
                // TODO: should log exception and then throw a custom exception
                throw e;
            }

            // Return result 
            return result;
        }
    }
}