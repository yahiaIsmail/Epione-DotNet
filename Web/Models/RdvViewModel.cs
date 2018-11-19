using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class RdvViewModel
    {
        [Required(ErrorMessage = "The email address is required")]
        public string emailPatient { get; set; }
        public string emailDoctor { get; set; }
        public int motifId { get; set; }
        public DateTime dateRdv { get; set; }
    }

    public class RdvModel
    {
        public string emailPatient { get; set; }
        public string emailDoctor { get; set; }
        public int motifId { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public int hour { get; set; }
        public int minutes { get; set; }
    }
}