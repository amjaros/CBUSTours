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
        private string SQL_RegisterUser = "INSERT INTO users VALUES (@user_email, @user_password, @user_name, 1);";

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
                    cmd.Parameters.AddWithValue("@user_name", user.User_name);
                    cmd.Parameters.AddWithValue("@user_password", user.User_password);
                    cmd.Parameters.AddWithValue("@user_email", user.User_email);
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
