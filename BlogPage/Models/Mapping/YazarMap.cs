using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BlogPage.Models.Mapping
{
    public class YazarMap : EntityTypeConfiguration<Yazar>
    {
        public YazarMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(50);

            this.Property(t => t.Soyadi)
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Yazar");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Soyadi).HasColumnName("Soyadi");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Tarixi).HasColumnName("Tarixi");
            this.Property(t => t.ResimID).HasColumnName("ResimID");
            this.Property(t => t.Aktivmi).HasColumnName("Aktivmi");

            // Relationships
            this.HasRequired(t => t.aspnet_Users)
                .WithOptional(t => t.Yazar);
            this.HasOptional(t => t.Resim)
                .WithMany(t => t.Yazars)
                .HasForeignKey(d => d.ResimID);

        }
    }
}
