using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Dapper;
using System.Data.SqlClient;
using Capstone.Web.Models;
using System.Configuration;
namespace Capstone.Web.DataAccess
{
    public class LandmarkReviewSQLDAL
    {
        public List<LandmarkReview> GetReviewsByLandmark(int landmark_id)
        {
            List<LandmarkReview> reviews = new List<LandmarkReview>();
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM reviews join reviews_by_landmark r on reviews.review_id = r.review_id WHERE landmark_id = @landmark_id");
                    cmd.Parameters.AddWithValue("@landmark_id", landmark_id);
                    cmd.Connection = conn;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while(reader.Read())
                    {
                        LandmarkReview review = new LandmarkReview();
                        review.ReviewID = Convert.ToInt32(reader["review_id"]);
                        int ratingStored = Convert.ToInt32(reader["rating"]);
                        if (ratingStored == 1)
                        {
                            review.Rating = true;
                        }
                        else
                        {
                            review.Rating = false;
                        }
                        review.Description = reader["description"].ToString();
                        reviews.Add(review);
                    }
                    return reviews;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool SubmitReview(int landmarkID, LandmarkReview review)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO reviews VALUES (@rating, @description)", conn);
                    int worked = cmd.ExecuteNonQuery();

                    SqlCommand cmd2 = new SqlCommand("", conn);

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int GetMostRecentLandmarkReviewId(int landmark_id)
        {
            int result = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetItinerary);
                    cmd.Parameters.AddWithValue("@itinerary_id", itineraryId);
                    cmd.Connection = connection;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Itinerary_id = itineraryId;
                        result.Name = reader["name"].ToString();
                        result.Starting_point = reader["starting_point"].ToString();
                        result.User_Id = Convert.ToInt32(reader["user_id"]);
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}