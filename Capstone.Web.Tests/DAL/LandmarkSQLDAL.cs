using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using Capstone.Web.Models;
using Capstone.Web.DataAccess;
using System.Transactions;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections.Generic;

namespace Capstone.Web.Tests.DAL
{
    [TestClass()]
    public class LandmarkSQLDAL
    {
        private TransactionScope tran;      //<-- used to begin a transaction during initialize and rollback during cleanup
        SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        // Set up the database before each test        
        [TestInitialize]
        public void Initialize()
        {
            // Initialize a new transaction scope. This automatically begins the transaction.
            tran = new TransactionScope();

            // Open a SqlConnection object using the active transaction
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd;
                              
                    cmd = new SqlCommand("INSERT INTO landmark VALUES('Statehouse', '123 Broad St', 'Capitol Building', 1, 'statehouse.jpg')", conn);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("INSERT INTO landmarks_by_itinerary VALUES(1,1)", conn);
                  
                }
            }}

        // Cleanup runs after every single test
        [TestCleanup]
        public void Cleanup()
        {
            tran.Dispose(); //<-- disposing the transaction without committing it means it will get rolled back
        }
        public void LandmarksByItinerary()
        {
            //Arrange
            LandmarkSQLDAL LMSQLDAL = new LandmarkSQLDAL();

            //Act
            //List<LandmarkModel> LandmarkList = LMSQLDAL. ("1");

            //Assert

            Assert.AreEqual(1,1);
        }
    }

}
