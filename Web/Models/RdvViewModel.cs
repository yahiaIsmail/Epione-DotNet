using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class RdvViewModel
    {
        [Required(ErrorMessage = "The email address is required")]
        public string emailPatient { get; set; }
        public string emailDoctor { get; set; }
        public int motifId { get; set; }
        public DateTime dateRdv { get; set; }

        public override string ToString()
        {
            return "EmailPatient : "+emailPatient + " email doctor: " + emailDoctor + " motifID : " + motifId + " dateRdv :  "+dateRdv  ;
        }
    }

    public class RdvModel
    {
        public user Users { get; set; }
        public user Doctors { get; set; }
        public motif Motif { get; set; }
        public DateTime DateRdv { get; set; }
    }

    public class MotifRdvModel
    {
        public int id { get; set; }
        public string description { get; set; }
        public user doctor { get; set; }

    }
}