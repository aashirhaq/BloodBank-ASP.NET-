using BloodBank.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BloodBank.ViewModel.UserDetail
{
    public class UserDetailViewModel
    {
        public List<BloodBank.Models.UserData> GetAllData()
        {

            {
                List<BloodBank.Models.UserData> userDetail = new List<BloodBank.Models.UserData>();
                string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_GetUserLoginData", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            BloodBank.Models.UserData ud = new BloodBank.Models.UserData();
                            ud.Id = Convert.ToInt32(reader["ID"]);
                            ud.FirstName = reader["First Name"].ToString();
                            ud.LastName = reader["Last Name"].ToString();
                            ud.Username = reader["Username"].ToString();
                            ud.EmailAddress = reader["Email address"].ToString();
                            ud.Password = reader["Password"].ToString();

                            userDetail.Add(ud);
                        }
                    }
                }

                return userDetail;
            }
        }

        public UserData GetUserDetail(int Id)
        {
            UserData ud = new UserData();

            string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetCurrentUserDetail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.AddWithValue("@Id", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    ud.Id = Convert.ToInt32(reader["ID"]);
                    ud.FirstName = reader["First Name"].ToString();
                    ud.LastName = reader["Last Name"].ToString();
                    ud.Username = reader["Username"].ToString();
                    ud.EmailAddress = reader["Email Address"].ToString();
                    ud.Password = reader["Password"].ToString();
                }
            }
            return ud;

        }

        public void UpdateUserDetail(UserData userData)
        {
            string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateUserDetail", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@Id", userData.Id);
                    cmd.Parameters.AddWithValue("@FirstName", userData.FirstName );
                    cmd.Parameters.AddWithValue("@LastName", userData.LastName);
                    cmd.Parameters.AddWithValue("@Username", userData.Username);
                    cmd.Parameters.AddWithValue("@EmailAddress", userData.EmailAddress);
                    cmd.Parameters.AddWithValue("@Password", userData.Password);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

}