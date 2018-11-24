
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   public class Context : DbContext
    {
        public Context(): base("name=epionnedatabaseContext")
        {

        }

        public System.Data.Entity.DbSet<Data.Models.medicalpath> medicalpath { get; set; }

        public System.Data.Entity.DbSet<Data.Models.user> user { get; set; }

        public System.Data.Entity.DbSet<Data.Models.rdv> rdv { get; set; }
    }
}
