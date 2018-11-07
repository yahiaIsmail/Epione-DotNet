using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class transport
    {
        public int id { get; set; }
        public string meansOfTransport { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public virtual user user { get; set; }
    }
}
