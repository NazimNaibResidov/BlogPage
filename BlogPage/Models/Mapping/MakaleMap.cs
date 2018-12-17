using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogPage.Models.Mapping
{
    public class MakaleMap : EntityTypeConfiguration<Makale>
    {
        public MakaleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Baslik)
                .HasMaxLength(100);

            this.Property(t => t.Kodlar)
                .HasMaxLength(1000);

            // Table & Column Mappings
            this.ToTable("Makale");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Baslik).HasColumnName("Baslik");
            this.Property(t => t.Icerik).HasColumnName("Icerik");
            this.Property(t => t.Kodlar).HasColumnName("Kodlar");
            this.Property(t => t.EkelemeTarixi).HasColumnName("EkelemeTarixi");
            this.Property(t => t.KategoriID).HasColumnName("KategoriID");
            this.Property(t => t.GoruntlemeSayi).HasColumnName("GoruntlemeSayi");
            this.Property(t => t.Begeni).HasColumnName("Begeni");
            this.Property(t => t.YazarID).HasColumnName("YazarID");
            this.Property(t => t.ResimID).HasColumnName("ResimID");

            // Relationships
            this.HasOptional(t => t.Kategori)
                .WithMany(t => t.Makales)
                .HasForeignKey(d => d.KategoriID);
            this.HasOptional(t => t.Resim)
                .WithMany(t => t.Makales)
                .HasForeignKey(d => d.ResimID);
            this.HasOptional(t => t.Yazar)
                .WithMany(t => t.Makales)
                .HasForeignKey(d => d.YazarID);

        }
    }
}
