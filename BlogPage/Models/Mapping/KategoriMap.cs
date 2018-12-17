using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogPage.Models.Mapping
{
    public class KategoriMap : EntityTypeConfiguration<Kategori>
    {
        public KategoriMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Kategori");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Adi).HasColumnName("Adi");
        }
    }
}
