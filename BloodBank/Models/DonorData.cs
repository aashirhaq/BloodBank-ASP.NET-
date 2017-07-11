using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloodBank.Models
{
    public class DonorData
    {
        public int DonorID { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public long ContactNumber { get; set; }
        public string BloodGroup { get; set; }
        public string DateOfBirth { get; set; }
    }
}