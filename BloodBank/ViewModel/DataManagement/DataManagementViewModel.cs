using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BloodBank.ViewModel.DataManagement
{
    public class DataManagementViewModel
    {
        public List<BloodBank.Models.DonorData> GetAllData()
        {

            {
                List<BloodBank.Models.DonorData> donorData = new List<BloodBank.Models.DonorData>();
                string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand cmd = new SqlCommand("usp_GetDonorData", conn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            BloodBank.Models.DonorData dd = new BloodBank.Models.DonorData();
                            dd.DonorID = Convert.ToInt32(reader["DonorID"]);
                            dd.FullName = reader["FullName"].ToString();
                            dd.Gender = reader["Gender"].ToString();
                            dd.Address = reader["Address"].ToString();
                            dd.ContactNumber = Convert.ToInt64(reader["Contact"]);
                            dd.BloodGroup = reader["BloodGroup"].ToString();
                            dd.DateOfBirth = reader["DateOfBirth"].ToString();

                            donorData.Add(dd);
                        }
                    }
                }

                return donorData;
            }
        }
    }
}