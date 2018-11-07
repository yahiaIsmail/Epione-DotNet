using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class transportMap : EntityTypeConfiguration<transport>
    {
        public transportMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.meansOfTransport)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("transport", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.meansOfTransport).HasColumnName("meansOfTransport");
            this.Property(t => t.doctor_id).HasColumnName("doctor_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.transports)
                .HasForeignKey(d => d.doctor_id);

        }
    }
}
