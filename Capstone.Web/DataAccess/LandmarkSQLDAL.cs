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
        private string SQL_DeleteLandmarkFromItinerary = "DELETE FROM landmarks_by_itinerary WHERE itinerary_id = @itineraryID";
        private string SQL_SelectLandmarksByItinerary = "SELECT * from landmark JOIN landmarks_by_itinerary on landmark.landmark_id= landmarks_by_itinerary.landmark_id WHERE itinerary_id=@itineraryID";

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
                    int worked = cmd.ExecuteNonQuery();
                    return (worked>0) ;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool InsertLandmarkIntoItinerary(string landmarkID, string itineraryID)
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

    }
}

