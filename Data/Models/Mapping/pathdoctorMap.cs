using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class pathdoctorMap : EntityTypeConfiguration<pathdoctor>
    {
        public pathdoctorMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("pathdoctors", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.ordre).HasColumnName("ordre");
            this.Property(t => t.doctor_id).HasColumnName("doctor_id");
            this.Property(t => t.path_id).HasColumnName("path_id");

            // Relationships
            this.HasOptional(t => t.medicalpath)
                .WithMany(t => t.pathdoctors)
                .HasForeignKey(d => d.path_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.pathdoctors)
                .HasForeignKey(d => d.doctor_id);

        }
    }
}
