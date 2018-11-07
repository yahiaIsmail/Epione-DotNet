using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class expertiseMap : EntityTypeConfiguration<expertise>
    {
        public expertiseMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.content)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("expertise", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.doctor_id).HasColumnName("doctor_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.expertises)
                .HasForeignKey(d => d.doctor_id);

        }
    }
}
