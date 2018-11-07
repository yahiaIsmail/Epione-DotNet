using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class userMap : EntityTypeConfiguration<user>
    {
        public userMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.UrlPhoto)
                .HasMaxLength(255);

            this.Property(t => t.confirmation)
                .HasMaxLength(255);

            this.Property(t => t.confirmationToken)
                .HasMaxLength(255);

            this.Property(t => t.email)
                .HasMaxLength(255);

            this.Property(t => t.firstName)
                .HasMaxLength(255);

            this.Property(t => t.language)
                .HasMaxLength(255);

            this.Property(t => t.lastName)
                .HasMaxLength(255);

            this.Property(t => t.paimentMethode)
                .HasMaxLength(255);

            this.Property(t => t.password)
                .HasMaxLength(255);

            this.Property(t => t.speciality)
                .HasMaxLength(255);

            this.Property(t => t.state)
                .HasMaxLength(255);

            this.Property(t => t.tariff)
                .HasMaxLength(255);

            this.Property(t => t.username)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("user", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.UrlPhoto).HasColumnName("UrlPhoto");
            this.Property(t => t.birthday).HasColumnName("birthday");
            this.Property(t => t.confirmation).HasColumnName("confirmation");
            this.Property(t => t.confirmationToken).HasColumnName("confirmationToken");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.enabled).HasColumnName("enabled");
            this.Property(t => t.firstName).HasColumnName("firstName");
            this.Property(t => t.language).HasColumnName("language");
            this.Property(t => t.lastLogin).HasColumnName("lastLogin");
            this.Property(t => t.lastName).HasColumnName("lastName");
            this.Property(t => t.paimentMethode).HasColumnName("paimentMethode");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.phoneNumber).HasColumnName("phoneNumber");
            this.Property(t => t.role).HasColumnName("role");
            this.Property(t => t.speciality).HasColumnName("speciality");
            this.Property(t => t.state).HasColumnName("state");
            this.Property(t => t.tariff).HasColumnName("tariff");
            this.Property(t => t.username).HasColumnName("username");
            this.Property(t => t.address_id).HasColumnName("address_id");

            // Relationships
            this.HasMany(t => t.conversations)
                .WithMany(t => t.users)
                .Map(m =>
                    {
                        m.ToTable("user_conversation", "epionnedatabase");
                        m.MapLeftKey("users_id");
                        m.MapRightKey("conversations_id");
                    });

            this.HasOptional(t => t.address)
                .WithMany(t => t.users)
                .HasForeignKey(d => d.address_id);

        }
    }
}
