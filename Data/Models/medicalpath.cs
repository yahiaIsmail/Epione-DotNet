using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class medicalpath
    {
        public medicalpath()
        {
            this.pathdoctors = new List<pathdoctor>();
        }

        public int id { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<System.DateTime> createdAt { get; set; }
        public string justification { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> rendezVous_id { get; set; }
        public virtual ICollection<pathdoctor> pathdoctors { get; set; }
        public virtual rdv rdv { get; set; }
    }
}
