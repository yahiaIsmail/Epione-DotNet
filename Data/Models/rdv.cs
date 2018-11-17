using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class rdv
    {
        public rdv()
        {
            this.medicalpaths = new List<medicalpath>();
        }

        public int id { get; set; }
        public bool confirmationDoc { get; set; }
        public bool confirmationPatient { get; set; }
        public Nullable<long> dateRDV { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> doctors_id { get; set; }
        public Nullable<int> motif_id { get; set; }
        public Nullable<int> users_id { get; set; }
        public virtual ICollection<medicalpath> medicalpaths { get; set; }
        public virtual motif motif { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
