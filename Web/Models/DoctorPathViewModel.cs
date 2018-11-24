using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;
using Web.fonts;

namespace Web.Models
{
    public class DoctorPathViewModel
    {
        public DoctorViewModel doctor { get; set; }

        public int id { get; set; }
        public int ordre { get; set; }
        public MedicalPathViewModel path { get; set; }
        public MedicalVisitViewModel medicalVisit { get; set; }


    }
}