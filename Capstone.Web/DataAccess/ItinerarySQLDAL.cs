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
    public class ItinerarySQLDAL
    {
        private string SQL_InsertNewItinerary = "INSERT INTO itinerary ([name], [user_id],[starting_point]) VALUES (@name, @user_id, @starting_point);";
        private string SQL_DeleteItinerary = "DELETE FROM landmarks_by_itinerary WHERE itinerary_id = @itinerary_id; DELETE FROM itinerary WHERE itinerary_id = @itinerary_id;";
        private string SQL_GetAllItineraries = "SELECT name, starting_point, user_id, itinerary_id FROM itinerary WHERE user_id = @user_id;";
        private string SQL_GetItinerary = "SELECT * FROM itinerary i WHERE itinerary_id = @itinerary_id";

        public bool InsertNewItinerary(ItineraryModel itinerary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    int rowsAffected = conn.Execute(SQL_InsertNewItinerary, new { name = itinerary.Name, user_id = itinerary.User_Id, starting_point = itinerary.Starting_point });
                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteItinerary(ItineraryModel itinerary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    int rowsAffected = conn.Execute(SQL_DeleteItinerary, new { itinerary_id = itinerary.Itinerary_id });
                    return (rowsAffected > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<ItineraryModel> GetAllItineraries(int user_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    List<ItineraryModel> itinList = conn.Query<ItineraryModel>(SQL_GetAllItineraries, new { user_id = user_id }).ToList();
                    return itinList;

                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public ItineraryModel GetItinerary(int itineraryId)
        {
            ItineraryModel result = new ItineraryModel();
            try
            {
                using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    result.Landmarks = new LandmarkSQLDAL().SelectLandmarksByItinerary(itineraryId.ToString());
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