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
    public class ItinerarySQLDAL
    {
        private string SQL_InsertNewItinerary = "INSERT INTO itinerary VALUES (@name, @user_id, @starting_point);";
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
    }
}