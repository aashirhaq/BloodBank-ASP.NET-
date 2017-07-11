using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BloodBank.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace BloodBank.ViewModel.DonorData
{
    public class DonorDataViewModel
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


        public void AddNewRecord(BloodBank.Models.DonorData donordata)
        {
            string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_CreateDonorRecord", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@FullName", donordata.FullName);
                    cmd.Parameters.AddWithValue("@Gender", donordata.Gender);
                    cmd.Parameters.AddWithValue("@Address", donordata.Address);
                    cmd.Parameters.AddWithValue("@Contact", donordata.ContactNumber);
                    cmd.Parameters.AddWithValue("@BloodGroup", donordata.BloodGroup);
                    cmd.Parameters.AddWithValue("@DateOfBirth", donordata.DateOfBirth);

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public BloodBank.Models.DonorData GetDonorDataById(int Id)
        {
            BloodBank.Models.DonorData dd = new BloodBank.Models.DonorData();

            string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetCurrentDonorData", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();
                    cmd.Parameters.AddWithValue("@DonorId", Id);

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();

                    dd.DonorID = Convert.ToInt32(reader["DonorID"]);
                    dd.FullName = reader["FullName"].ToString();
                    dd.Gender = reader["Gender"].ToString();
                    dd.Address = reader["Address"].ToString();
                    dd.ContactNumber = Convert.ToInt64(reader["Contact"]);
                    dd.BloodGroup = reader["BloodGroup"].ToString();
                    dd.DateOfBirth = reader["DateOfBirth"].ToString();
                }
            }
            return dd;

        }

        public void UpdateDonorData(BloodBank.Models.DonorData donorData)
        {
            string connString = ConfigurationManager.ConnectionStrings["bbdb"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_UpdateDonorData", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    conn.Open();

                    cmd.Parameters.AddWithValue("@DonorId", donorData.DonorID);
                    cmd.Parameters.AddWithValue("@FullName", donorData.FullName);
                    cmd.Parameters.AddWithValue("@Gender", donorData.Gender);
                    cmd.Parameters.AddWithValue("@Address", donorData.Address);
                    cmd.Parameters.AddWithValue("@Contact", donorData.ContactNumber);
                    cmd.Parameters.AddWithValue("@BloodGroup", donorData.BloodGroup);
                    cmd.Parameters.AddWithValue("@DateOfBirth", donorData.DateOfBirth);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }


    
}