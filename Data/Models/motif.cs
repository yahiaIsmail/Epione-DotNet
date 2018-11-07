using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class motif
    {
        public motif()
        {
            this.rdvs = new List<rdv>();
        }

        public int id { get; set; }
        public string description { get; set; }
        public Nullable<int> doctor_id { get; set; }
        public virtual user user { get; set; }
        public virtual ICollection<rdv> rdvs { get; set; }
    }
}
