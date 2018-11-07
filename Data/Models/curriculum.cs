using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class curriculum
    {
        public int id { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> diplomaDate { get; set; }
    }
}
