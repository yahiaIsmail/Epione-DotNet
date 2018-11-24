using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;

namespace Web.Models
{
    public class MedicalPathViewModel
    {

        public int id { get; set; }
        public Boolean active { get; set; }
        public long createdAt { get; set; }
        public string justification { get; set; }
        public Boolean status { get; set; }


        public List<DoctorPathViewModel> doctorPath { get; set; }
        public RdvForMedicalViewModel rendezVous { get; set; }
    }
}