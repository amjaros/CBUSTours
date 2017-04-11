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
        private string SQL_InsertNewItinerary = "INSERT INTO itinerary VALUES (@name, @user_id, @starting_point);SELECT CAST(itinerary_id() as int)";
        private string SQL_DeleteItinerary = "DELETE FROM itinerary WHERE itinerary_id = @itinerary_id;";
        private string SQL_GetAllItineraries = "SELECT name FROM itinerary WHERE user_id = @user_id;";

        public bool InsertNewItinerary(ItineraryModel itinerary)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    
                    return (1 > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool DeleteItinerary(ItineraryModel itinerary, int user_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    int rowsAffected = conn.Execute(SQL_InsertNewItinerary, itinerary);
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
    }
}