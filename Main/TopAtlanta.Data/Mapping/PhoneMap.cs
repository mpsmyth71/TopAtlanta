using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Data.Mapping
{
    public class PhoneMap : EntityTypeConfiguration<Phone>
    {
        public PhoneMap()
        {
            // Primary Key
            this.HasKey(t => t.PhoneId);

            // Properties
            this.Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Extension)
                .HasMaxLength(5);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Phone");
            this.Property(t => t.PhoneId).HasColumnName("PhoneId");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.PhoneTypeId).HasColumnName("PhoneTypeId");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Extension).HasColumnName("Extension");
            this.Property(t => t.IsPrimary).HasColumnName("IsPrimary");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.Phones)
                .HasForeignKey(d => d.ContactId);
            this.HasRequired(t => t.PhoneType)
                .WithMany(t => t.Phones)
                .HasForeignKey(d => d.PhoneTypeId);

        }
    }
}
