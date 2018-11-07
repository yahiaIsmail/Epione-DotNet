using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class messagedoctor
    {
        public int id { get; set; }
        public string content { get; set; }
        public string @object { get; set; }
        public Nullable<int> user_id { get; set; }
        public virtual user user { get; set; }
    }
}
