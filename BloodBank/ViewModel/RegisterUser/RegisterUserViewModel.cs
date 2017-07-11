using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BloodBank.ViewModel.RegisterUser
{
    public class RegisterUserViewModel
    {
        public void RegisterUser(BloodBank.Models.UserData userData)
        {
            string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_RegisterUser", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@FirstName", userData.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", userData.LastName);
                    cmd.Parameters.AddWithValue("@UserName", userData.Username);
                    cmd.Parameters.AddWithValue("@EmailAddress", userData.EmailAddress);
                    cmd.Parameters.AddWithValue("@Password", userData.Password);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}