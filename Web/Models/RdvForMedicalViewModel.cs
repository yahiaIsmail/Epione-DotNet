using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;

namespace Web.Models
{
    public class RdvForMedicalViewModel
    {
        public int id { get; set; }
        public bool confirmationDoc { get; set; }
        public bool confirmationPatient { get; set; }
        public long dateRDV { get; set; }
        public string status { get; set; }
        public DoctorViewModel doctors { get; set; }
        public DoctorViewModel users { get; set; }
    }
}