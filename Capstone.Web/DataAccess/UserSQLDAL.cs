using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HistoryGeek.Web.Models;
using Dapper;
using System.Data.SqlClient;

namespace Capstone.Web.DataAccess
{
    public class UserSQLDAL
    {
        private string connectionString = @"Data Source=DESKTOP-4EOMNFH\sqlexpress;Initial Catalog=CBUSTours;Integrated Security=True";
        private string SQL_GetUser = "SELECT* FROM users WHERE user_id = @user_id;";
        private string SQL_SaveUser = "INSERT INTO users VALUES (@user_email, @user_password, @user_name, @user_admin); SELECT CAST(SCOPE_IDENTITY() as int);";

        public UserSQLDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public User GetUser(int user_id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    User result = conn.QueryFirstOrDefault<User>(SQL_GetUser, new { user_id = user_id });
                    return result;
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public void SaveUser(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    user.Id = conn.QueryFirst<int>(SQL_SaveUser, new { emailValue = user.Email, passwordValue = user.Password });
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}
