using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;

namespace Data.Models
{
    public partial class epionnedatabaseContext : DbContext
    {
        static epionnedatabaseContext()
        {
            Database.SetInitializer<epionnedatabaseContext>(null);
        }

        public epionnedatabaseContext()
            : base("Name=epionnedatabaseContext")
        {
        }

        public DbSet<address> addresses { get; set; }
        public DbSet<conversation> conversations { get; set; }
        public DbSet<curriculum> curricula { get; set; }
        public DbSet<demande> demandes { get; set; }
        public DbSet<expertise> expertises { get; set; }
        public DbSet<medicalpath> medicalpaths { get; set; }
        public DbSet<medicalvisit> medicalvisits { get; set; }
        public DbSet<messagedoctor> messagedoctors { get; set; }
        public DbSet<motif> motifs { get; set; }
        public DbSet<pathdoctor> pathdoctors { get; set; }
        public DbSet<rdv> rdvs { get; set; }
        public DbSet<recievedmessage> recievedmessages { get; set; }
        public DbSet<sentmessage> sentmessages { get; set; }
        public DbSet<t_todo> t_todo { get; set; }
        public DbSet<transport> transports { get; set; }
        public DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new addressMap());
            modelBuilder.Configurations.Add(new conversationMap());
            modelBuilder.Configurations.Add(new curriculumMap());
            modelBuilder.Configurations.Add(new demandeMap());
            modelBuilder.Configurations.Add(new expertiseMap());
            modelBuilder.Configurations.Add(new medicalpathMap());
            modelBuilder.Configurations.Add(new medicalvisitMap());
            modelBuilder.Configurations.Add(new messagedoctorMap());
            modelBuilder.Configurations.Add(new motifMap());
            modelBuilder.Configurations.Add(new pathdoctorMap());
            modelBuilder.Configurations.Add(new rdvMap());
            modelBuilder.Configurations.Add(new recievedmessageMap());
            modelBuilder.Configurations.Add(new sentmessageMap());
            modelBuilder.Configurations.Add(new t_todoMap());
            modelBuilder.Configurations.Add(new transportMap());
            modelBuilder.Configurations.Add(new userMap());
        }
    }
}
