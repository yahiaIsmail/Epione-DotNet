using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [Table("rdv")]
    public partial class rdv
    {
       

        public int id { get; set; }
        public bool confirmationDoc { get; set; }
        public bool confirmationPatient { get; set; }
        //public Nullable<long> dateRDV { get; set; }
        public DateTime dateRDV { get; set; }
        public Nullable<int> status { get; set; }
        public Nullable<int> doctors_id { get; set; }
        public Nullable<int> motif_id { get; set; }
        public Nullable<int> users_id { get; set; }
       
        public virtual motif motif { get; set; }
        public virtual user user { get; set; }
        public virtual user user1 { get; set; }
    }
}
