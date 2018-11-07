using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class addressMap : EntityTypeConfiguration<address>
    {
        public addressMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.fullAddress)
                .HasMaxLength(255);

            this.Property(t => t.latitude)
                .HasMaxLength(255);

            this.Property(t => t.longit)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("address", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fullAddress).HasColumnName("fullAddress");
            this.Property(t => t.latitude).HasColumnName("latitude");
            this.Property(t => t.longit).HasColumnName("longit");
        }
    }
}
