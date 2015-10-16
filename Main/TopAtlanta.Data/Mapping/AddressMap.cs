using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Data.Mapping
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.AddressId);

            // Properties
            this.Property(t => t.AddressId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Addressline1)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Addressline2)
                .HasMaxLength(100);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.State)
                .IsRequired()
                .HasMaxLength(4);

            this.Property(t => t.PostalCode)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Address");
            this.Property(t => t.AddressId).HasColumnName("AddressId");
            this.Property(t => t.AddressTypeId).HasColumnName("AddressTypeId");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.Addressline1).HasColumnName("Addressline1");
            this.Property(t => t.Addressline2).HasColumnName("Addressline2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.State).HasColumnName("State");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.IsPrimary).HasColumnName("IsPrimary");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasRequired(t => t.AddressType)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.AddressTypeId);
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.ContactId);

        }
    }
}
