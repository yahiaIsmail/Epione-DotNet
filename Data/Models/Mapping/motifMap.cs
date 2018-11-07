using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class motifMap : EntityTypeConfiguration<motif>
    {
        public motifMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("motif", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.doctor_id).HasColumnName("doctor_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.motifs)
                .HasForeignKey(d => d.doctor_id);

        }
    }
}
