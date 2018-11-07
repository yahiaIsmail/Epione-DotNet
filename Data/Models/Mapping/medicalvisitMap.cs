using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class medicalvisitMap : EntityTypeConfiguration<medicalvisit>
    {
        public medicalvisitMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("medicalvisit", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.createdAt).HasColumnName("createdAt");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.medicalState).HasColumnName("medicalState");
            this.Property(t => t.rating).HasColumnName("rating");
            this.Property(t => t.pathDoctors_id).HasColumnName("pathDoctors_id");

            // Relationships
            this.HasOptional(t => t.pathdoctor)
                .WithMany(t => t.medicalvisits)
                .HasForeignKey(d => d.pathDoctors_id);

        }
    }
}
