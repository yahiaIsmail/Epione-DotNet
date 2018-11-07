using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class expertise
    {
        public int id { get; set; }
        public string content { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public virtual user user { get; set; }
    }
}
