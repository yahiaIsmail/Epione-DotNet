using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PatientForMedicalPathViewModel
    {
        public int id { get; set; }
        public string UrlPhoto { get; set; }


        public string email { get; set; }

        public string firstName { get; set; }


        public string lastName { get; set; }

        public int phoneNumber { get; set; }

        public string speciality { get; set; }

        public string tariff { get; set; }
        public int address_id { get; set; }

        public AddressViewModel address { get; set; }
        public string state { get; set; }

    }
}