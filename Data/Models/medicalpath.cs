using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("medicalpath")]
    public partial class medicalpath
    {
        public medicalpath()
        {
            this.pathdoctors = new List<pathdoctor>();
        }

        public int id { get; set; }
        public Nullable<bool> active { get; set; }
        public Nullable<long> createdAt { get; set; }
        public string justification { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> rendezVous_id { get; set; }
        public virtual ICollection<pathdoctor> pathdoctors { get; set; }
        public virtual rdv rdv { get; set; }
    }
}
