using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Data.Models
{
    public partial class demande
    {
        public int id { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string speciality { get; set; }
        public string state { get; set; }
    }
}
