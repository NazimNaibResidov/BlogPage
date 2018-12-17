using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogPage.Models.Mapping
{
    public class ResimMap : EntityTypeConfiguration<Resim>
    {
        public ResimMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(50);

            this.Property(t => t.Samll)
                .HasMaxLength(251);

            this.Property(t => t.Midel)
                .HasMaxLength(251);

            this.Property(t => t.Big)
                .HasMaxLength(251);

            this.Property(t => t.Yazar)
                .HasMaxLength(251);

            this.Property(t => t.Slider)
                .HasMaxLength(251);

            // Table & Column Mappings
            this.ToTable("Resim");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Samll).HasColumnName("Samll");
            this.Property(t => t.Midel).HasColumnName("Midel");
            this.Property(t => t.Big).HasColumnName("Big");
            this.Property(t => t.Yazar).HasColumnName("Yazar");
            this.Property(t => t.Slider).HasColumnName("Slider");
        }
    }
}
