using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class AddressViewModel
    {
        public int id { get; set; }
        public string fullAddress { get; set; }
        public string latitude { get; set; }
        public string longit { get; set; }
    }
}