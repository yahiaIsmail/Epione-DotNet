using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class pathdoctor
    {
        public pathdoctor()
        {
            this.medicalvisits = new List<medicalvisit>();
        }

        public int id { get; set; }
        public int ordre { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public Nullable<int> path_id { get; set; }
        public virtual medicalpath medicalpath { get; set; }
        public virtual ICollection<medicalvisit> medicalvisits { get; set; }
        public virtual user user { get; set; }
    }
}
