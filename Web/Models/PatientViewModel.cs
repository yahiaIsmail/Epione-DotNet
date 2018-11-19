using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PatientViewModel
    {

        [Required(ErrorMessage = "The firstname password address is required")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "The lastname password address is required")]
        public string lastName { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }
        [Required(ErrorMessage = "The username password address is required")]
        public string username { get; set; }
        [Required(ErrorMessage = "The password address is required")]
        public string password { get; set; }
        [Required(ErrorMessage = "The validate password address is required")]
        [Compare("password")]
        public string validatePassword { get; set; }
    }

    public class PatientModel
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}