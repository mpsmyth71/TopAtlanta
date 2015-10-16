using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Data.Mapping
{
    public class AccountGroupMap : EntityTypeConfiguration<AccountGroup>
    {
        public AccountGroupMap()
        {
            // Primary Key
            this.HasKey(t => new { t.GroupId, t.AccountId });

            // Properties
            this.Property(t => t.GroupId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.AccountId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("AccountGroup");
            this.Property(t => t.GroupId).HasColumnName("GroupId");
            this.Property(t => t.AccountId).HasColumnName("AccountId");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdateDate).HasColumnName("UpdateDate");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");

            // Relationships
            this.HasRequired(t => t.Account)
                .WithMany(t => t.AccountGroups)
                .HasForeignKey(d => d.AccountId);
            this.HasRequired(t => t.Group)
                .WithMany(t => t.AccountGroups)
                .HasForeignKey(d => d.GroupId);

        }
    }
}
