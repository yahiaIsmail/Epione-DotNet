using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class conversationMap : EntityTypeConfiguration<conversation>
    {
        public conversationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("conversation", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dateCreated).HasColumnName("dateCreated");
        }
    }
}
