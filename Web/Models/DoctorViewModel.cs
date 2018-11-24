using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Models;

namespace Web.Models
{
    public class DoctorViewModel
    {

        public int id { get; set; }
        public string UrlPhoto { get; set; }
     
      
        public string email { get; set; }
       
        public string firstName { get; set; }
       
    
        public string lastName { get; set; }
     
        public int phoneNumber { get; set; }
      
        public string speciality { get; set; }
      
        public string tariff { get; set; }
       
     
        public virtual address address { get; set; }
        public string state { get; set; }



    }

}