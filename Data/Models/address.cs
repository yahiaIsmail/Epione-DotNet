using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class address
    {
        public address()
        {
            this.users = new List<user>();
        }

        public int id { get; set; }
        public string fullAddress { get; set; }
        public string latitude { get; set; }
        public string longit { get; set; }
        public virtual ICollection<user> users { get; set; }
    }
}
