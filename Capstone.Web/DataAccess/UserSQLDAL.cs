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
    public class UserSQLDAL
    {
        private string SQL_LoginUser = "SELECT* FROM users WHERE user_name = @user_name AND user_password = @user_password;";
        private string SQL_RegisterUser = "INSERT INTO users VALUES (@user_name, @user_email, @user_password, 1);";
        private string doesUsernameAlreadyExist = "SELECT * FROM users WHERE user_name = @SUsername";

        public UserLoginModel LoginUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    UserLoginModel result = conn.QueryFirstOrDefault<UserLoginModel>(SQL_LoginUser, new { user_name = username, user_password = password });
                    return result;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool RegisterUser(UserRegisterModel user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_RegisterUser, conn);
                    cmd.Parameters.AddWithValue("@user_name", user.Username);
                    cmd.Parameters.AddWithValue("@user_password", user.Password);
                    cmd.Parameters.AddWithValue("@user_email", user.EmailAddress);
                    int result = cmd.ExecuteNonQuery();
                    return (result > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public bool UserNameAlreadyExists(string Username)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(doesUsernameAlreadyExist, conn);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    int result = cmd.ExecuteNonQuery();
                    return (result > 0);
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
