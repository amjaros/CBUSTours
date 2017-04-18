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
    public class ReviewSQLDAL
    {

        private string SQL_SubmitReview = "INSERT INTO reviews VALUES (@landmark_id, @rating, @description)";
        private string SQL_GetAllReviews = "SELECT reviews.review_id, rating, description FROM reviews JOIN reviews_by_landmark ON reviews.review_id = reviews_by_landmark.review_id WHERE reviews_by_landmark.landmark_id = @landmark_id;";

        public bool InsertNewReview(ReviewModel review, int landmarkID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    //int rowsAffected = conn.Execute(SQL_SubmitReview, new { rating = review.Rating, description = review.Description, landmarkID = landmarkID });
                    SqlCommand cmd = new SqlCommand(SQL_SubmitReview, conn);
                    cmd.Parameters.AddWithValue("@landmark_id", landmarkID);
                    cmd.Parameters.AddWithValue("@rating", review.Rating);
                    cmd.Parameters.AddWithValue("@description", review.Description);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<ReviewModel> GetAllReviews(int landmark_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    List<ReviewModel> reviewsList = conn.Query<ReviewModel>(SQL_GetAllReviews, new { landmark_id = landmark_id }).ToList();
                    return reviewsList;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}