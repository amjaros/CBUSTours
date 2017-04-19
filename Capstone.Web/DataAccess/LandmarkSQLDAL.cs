using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Capstone.Web.Models;

namespace Capstone.Web.DataAccess
{
    public class LandmarkSQLDAL
    {
        private string SQL_InsertLandmarkIntoItinerary = "INSERT INTO landmarks_by_itinerary VALUES (@itineraryID, @landmarkID)";
        private string SQL_DeleteLandmarkFromItinerary = "DELETE FROM landmarks_by_itinerary WHERE itinerary_id = @itineraryID AND landmark_id = @landmarkID";
        private string SQL_SelectLandmarksByItinerary = "SELECT * from landmark JOIN landmarks_by_itinerary on landmark.landmark_id= landmarks_by_itinerary.landmark_id WHERE itinerary_id=@itineraryID";
        private string SQL_GetApprovedLandmarks = "SELECT * FROM landmark WHERE approved= 1";
        private string SQL_GetLandmarkByID = "SELECT * FROM landmark WHERE landmark_id= @landmarkID";
        private string SQL_SubmitReview = "INSERT INTO reviews VALUES (@landmark_id, @rating, @description)";

        public LandmarkModel GetLandmarkById(int landmarkID)
        {
            LandmarkModel Landmark = new LandmarkModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetLandmarkByID, conn);
                    cmd.Parameters.AddWithValue("@landmarkID", landmarkID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Landmark.address = Convert.ToString(reader["address"]);
                        Landmark.landmark_id = Convert.ToInt32(reader["landmark_id"]);
                        Landmark.name = Convert.ToString(reader["name"]);
                        Landmark.description = Convert.ToString(reader["description"]);
                        Landmark.approved = Convert.ToBoolean(reader["approved"]);
                        Landmark.image = Convert.ToString(reader["image"]);
                    }
                    reader.Close();


                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM reviews WHERE landmark_id = @landmark_id", conn);
                    cmd2.Parameters.AddWithValue("@landmark_id", landmarkID);
                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    List<ReviewModel> reviews = new List<ReviewModel>();
                    while(reader2.Read())
                    {
                        ReviewModel review = new ReviewModel();
                        review.Description = reader2["description"].ToString();
                        review.Rating = Convert.ToBoolean(reader2["rating"]);
                        review.ReviewID = Convert.ToInt32(reader2["review_id"]);

                        reviews.Add(review);
                    }
                    Landmark.Reviews = reviews;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return Landmark;
        }

        public List<LandmarkModel> GetApprovedLandmarks()
        {
            List<LandmarkModel> LandmarkList = new List<LandmarkModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetApprovedLandmarks, conn);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LandmarkModel Landmark = new LandmarkModel();
                        Landmark.address = Convert.ToString(reader["address"]);
                        Landmark.landmark_id = Convert.ToInt32(reader["landmark_id"]);
                        Landmark.name = Convert.ToString(reader["name"]);
                        Landmark.description = Convert.ToString(reader["description"]);
                        Landmark.approved = Convert.ToBoolean(reader["approved"]);
                        Landmark.image = Convert.ToString(reader["image"]);
                        LandmarkList.Add(Landmark);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return LandmarkList;
        }


        public List<LandmarkModel> SelectLandmarksByItinerary(string itineraryID)
        {
            List<LandmarkModel> LandmarkList = new List<LandmarkModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SelectLandmarksByItinerary, conn);
                    cmd.Parameters.AddWithValue("@itineraryID", itineraryID);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LandmarkModel Landmark = new LandmarkModel();
                        Landmark.address = Convert.ToString(reader["address"]);
                        Landmark.landmark_id = Convert.ToInt32(reader["landmark_id"]);
                        Landmark.name = Convert.ToString(reader["name"]);
                        Landmark.description = Convert.ToString(reader["description"]);
                        Landmark.approved = Convert.ToBoolean(reader["approved"]);
                        Landmark.image = Convert.ToString(reader["image"]);

                        LandmarkList.Add(Landmark);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            return LandmarkList;
        }

        public bool DeleteLandmarkFromItinerary(string landmarkID, string itineraryID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_DeleteLandmarkFromItinerary, conn);
                    cmd.Parameters.AddWithValue("@itineraryID", itineraryID);
                    cmd.Parameters.AddWithValue("@landmarkID", landmarkID);
                    int worked = cmd.ExecuteNonQuery();
                    return (worked > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool InsertLandmarkIntoItinerary(int landmarkID, int itineraryID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_InsertLandmarkIntoItinerary, conn);
                    cmd.Parameters.AddWithValue("@landmarkID", landmarkID);
                    cmd.Parameters.AddWithValue("@itineraryID", itineraryID);
                    int worked = cmd.ExecuteNonQuery();
                    return (worked > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool isLandmarkAlreadyInItinerary(int landmark_id, int itinerary_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM landmarks_by_itinerary WHERE itinerary_id = @itineraryID AND landmark_id = @landmarkID", conn);
                    cmd.Parameters.AddWithValue("@landmarkID", landmark_id);
                    cmd.Parameters.AddWithValue("@itineraryID", itinerary_id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    int rowsAffected = 0;
                    while(reader.Read())
                    {
                        rowsAffected++;
                    }
                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}

