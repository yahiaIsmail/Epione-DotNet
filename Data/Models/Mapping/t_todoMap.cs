using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class t_todoMap : EntityTypeConfiguration<t_todo>
    {
        public t_todoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.text)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("t_todo", "epionnedatabase");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.text).HasColumnName("text");
        }
    }
}
