using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class UserViewModel
    {
        public int userId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
    }
}