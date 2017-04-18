﻿using System;
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
        private string SQL_InsertNewReview = "INSERT INTO reviews ([rating], [description], [landmark_id]) VALUES (@rating, @description, @landmark_id);";
        private string SQL_GetAllReviews = "SELECT reviews.review_id, rating, description FROM reviews WHERE landmark_id = @landmark_id;";

        public bool InsertNewReview(ReviewModel review, int landmarkID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    int rowsAffected = conn.Execute(SQL_InsertNewReview, new { rating = review.Rating, description = review.Description, landmarkID = landmarkID });
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