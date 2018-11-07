using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class rdvMap : EntityTypeConfiguration<rdv>
    {
        public rdvMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("rdv", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.confirmationDoc).HasColumnName("confirmationDoc");
            this.Property(t => t.confirmationPatient).HasColumnName("confirmationPatient");
            this.Property(t => t.dateRDV).HasColumnName("dateRDV");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.doctors_id).HasColumnName("doctors_id");
            this.Property(t => t.motif_id).HasColumnName("motif_id");
            this.Property(t => t.users_id).HasColumnName("users_id");

            // Relationships
            this.HasOptional(t => t.motif)
                .WithMany(t => t.rdvs)
                .HasForeignKey(d => d.motif_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.rdvs)
                .HasForeignKey(d => d.users_id);
            this.HasOptional(t => t.user1)
                .WithMany(t => t.rdvs1)
                .HasForeignKey(d => d.doctors_id);

        }
    }
}
