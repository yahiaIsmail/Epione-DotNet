using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class MotifViewModel
    {
        public MotifViewModel()
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