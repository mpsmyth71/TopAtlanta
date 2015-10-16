using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Data.Mapping
{
    public class EmailAddressMap : EntityTypeConfiguration<EmailAddress>
    {
        public EmailAddressMap()
        {
            // Primary Key
            this.HasKey(t => t.EmailAddressId);

            // Properties
            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("EmailAddress");
            this.Property(t => t.EmailAddressId).HasColumnName("EmailAddressId");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.IsPrimary).HasColumnName("IsPrimary");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.EmailAddresses)
                .HasForeignKey(d => d.ContactId);

        }
    }
}
