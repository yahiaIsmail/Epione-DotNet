using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class medicalpathMap : EntityTypeConfiguration<medicalpath>
    {
        public medicalpathMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.justification)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("medicalpath", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.active).HasColumnName("active");
            this.Property(t => t.createdAt).HasColumnName("createdAt");
            this.Property(t => t.justification).HasColumnName("justification");
            this.Property(t => t.status).HasColumnName("status");
            this.Property(t => t.rendezVous_id).HasColumnName("rendezVous_id");

            // Relationships
            this.HasOptional(t => t.rdv)
                .WithMany(t => t.medicalpaths)
                .HasForeignKey(d => d.rendezVous_id);

        }
    }
}
