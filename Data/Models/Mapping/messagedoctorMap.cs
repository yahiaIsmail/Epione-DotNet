using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class messagedoctorMap : EntityTypeConfiguration<messagedoctor>
    {
        public messagedoctorMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.content)
                .HasMaxLength(255);

            this.Property(t => t.@object)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("messagedoctor", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.@object).HasColumnName("object");
            this.Property(t => t.user_id).HasColumnName("user_id");

            // Relationships
            this.HasOptional(t => t.user)
                .WithMany(t => t.messagedoctors)
                .HasForeignKey(d => d.user_id);

        }
    }
}
