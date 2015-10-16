using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Data.Mapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            // Primary Key
            this.HasKey(t => t.ContactId);

            // Properties
            this.Property(t => t.Title)
                .HasMaxLength(25);

            this.Property(t => t.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.MiddleName)
                .HasMaxLength(50);

            this.Property(t => t.Suffix)
                .HasMaxLength(10);

            this.Property(t => t.NickName)
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Company)
                .HasMaxLength(50);

            this.Property(t => t.JobTitle)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Contact");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.MiddleName).HasColumnName("MiddleName");
            this.Property(t => t.Suffix).HasColumnName("Suffix");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.JobTitle).HasColumnName("JobTitle");
            this.Property(t => t.Birthday).HasColumnName("Birthday");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
        }
    }
}
