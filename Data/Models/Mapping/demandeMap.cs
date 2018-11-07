using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class demandeMap : EntityTypeConfiguration<demande>
    {
        public demandeMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.speciality)
                .HasMaxLength(255);

            this.Property(t => t.state)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("demande", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.speciality).HasColumnName("speciality");
            this.Property(t => t.state).HasColumnName("state");
        }
    }
}
