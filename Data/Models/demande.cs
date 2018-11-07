using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class demande
    {
        public int id { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string speciality { get; set; }
        public string state { get; set; }
    }
}
