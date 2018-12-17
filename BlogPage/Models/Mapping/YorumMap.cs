using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogPage.Models.Mapping
{
    public class YorumMap : EntityTypeConfiguration<Yorum>
    {
        public YorumMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Icerik)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Yorum");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Icerik).HasColumnName("Icerik");
            this.Property(t => t.YazarID).HasColumnName("YazarID");
            this.Property(t => t.MakaleID).HasColumnName("MakaleID");
            this.Property(t => t.EkelemeTarixi).HasColumnName("EkelemeTarixi");

            // Relationships
            this.HasOptional(t => t.Makale)
                .WithMany(t => t.Yorums)
                .HasForeignKey(d => d.MakaleID);
            this.HasOptional(t => t.Yazar)
                .WithMany(t => t.Yorums)
                .HasForeignKey(d => d.YazarID);

        }
    }
}
