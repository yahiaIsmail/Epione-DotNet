using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class recievedmessageMap : EntityTypeConfiguration<recievedmessage>
    {
        public recievedmessageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.content)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("recievedmessage", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.dateCreated).HasColumnName("dateCreated");
            this.Property(t => t.conversation_id).HasColumnName("conversation_id");

            // Relationships
            this.HasOptional(t => t.conversation)
                .WithMany(t => t.recievedmessages)
                .HasForeignKey(d => d.conversation_id);

        }
    }
}
