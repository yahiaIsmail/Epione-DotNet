using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class user
    {
        public user()
        {
            this.expertises = new List<expertise>();
            this.messagedoctors = new List<messagedoctor>();
            this.motifs = new List<motif>();
            this.pathdoctors = new List<pathdoctor>();
            this.rdvs = new List<rdv>();
            this.rdvs1 = new List<rdv>();
            this.sentmessages = new List<sentmessage>();
            this.transports = new List<transport>();
            this.conversations = new List<conversation>();
        }

        public int id { get; set; }
        public string UrlPhoto { get; set; }
        public Nullable<System.DateTime> birthday { get; set; }
        public string confirmation { get; set; }
        public string confirmationToken { get; set; }
        public string email { get; set; }
        public bool enabled { get; set; }
        public string firstName { get; set; }
        public string language { get; set; }
        public Nullable<System.DateTime> lastLogin { get; set; }
        public string lastName { get; set; }
        public string paimentMethode { get; set; }
        public string password { get; set; }
        public int phoneNumber { get; set; }
        public Nullable<int> role { get; set; }
        public string speciality { get; set; }
        public string state { get; set; }
        public string tariff { get; set; }
        public string username { get; set; }
        public Nullable<int> address_id { get; set; }
        public virtual address address { get; set; }
        public virtual ICollection<expertise> expertises { get; set; }
        public virtual ICollection<messagedoctor> messagedoctors { get; set; }
        public virtual ICollection<motif> motifs { get; set; }
        public virtual ICollection<pathdoctor> pathdoctors { get; set; }
        public virtual ICollection<rdv> rdvs { get; set; }
        public virtual ICollection<rdv> rdvs1 { get; set; }
        public virtual ICollection<sentmessage> sentmessages { get; set; }
        public virtual ICollection<transport> transports { get; set; }
        public virtual ICollection<conversation> conversations { get; set; }
    }
}
