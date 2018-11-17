using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class medicalvisit
    {
        public int id { get; set; }
        public Nullable<long> createdAt { get; set; }
        public string description { get; set; }
        public Nullable<bool> medicalState { get; set; }
        public int rating { get; set; }
        public Nullable<int> pathDoctors_id { get; set; }
        public virtual pathdoctor pathdoctor { get; set; }
    }
}
