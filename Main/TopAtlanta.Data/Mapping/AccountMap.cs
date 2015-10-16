using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Data.Mapping
{
    public class AccountMap : EntityTypeConfiguration<Account>
    {
        public AccountMap()
        {
            // Primary Key
            this.HasKey(t => t.AccountId);

            // Properties
            this.Property(t => t.Source)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Account");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.ContactId).HasColumnName("ContactId");
            this.Property(t => t.AccountTypeId).HasColumnName("AccountTypeId");
            this.Property(t => t.AccountStatusesId).HasColumnName("AccountStatusesId");
            this.Property(t => t.TimeFrameId).HasColumnName("TimeFrameId");
            this.Property(t => t.MemberAgentId).HasColumnName("MemberAgentId");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.Notes).HasColumnName("Notes");
            this.Property(t => t.Referral).HasColumnName("Referral");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasRequired(t => t.AccountStatus)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.AccountStatusesId);
            this.HasRequired(t => t.AccountType)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.AccountTypeId);
            this.HasRequired(t => t.Contact)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.ContactId);
            this.HasOptional(t => t.MemberAgent)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.MemberAgentId);
            this.HasOptional(t => t.TimeFrame)
                .WithMany(t => t.Accounts)
                .HasForeignKey(d => d.TimeFrameId);

        }
    }
}
