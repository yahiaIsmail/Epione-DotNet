using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class sentmessageMap : EntityTypeConfiguration<sentmessage>
    {
        public sentmessageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.content)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("sentmessage", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.dateCreated).HasColumnName("dateCreated");
            this.Property(t => t.conversation_id).HasColumnName("conversation_id");
            this.Property(t => t.sender_id).HasColumnName("sender_id");

            // Relationships
            this.HasOptional(t => t.conversation)
                .WithMany(t => t.sentmessages)
                .HasForeignKey(d => d.conversation_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.sentmessages)
                .HasForeignKey(d => d.sender_id);

        }
    }
}
