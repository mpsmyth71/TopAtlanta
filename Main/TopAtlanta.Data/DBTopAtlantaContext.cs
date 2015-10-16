using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Repository.Infrastructure;
using TopAtlanta.Entities.Models;
using TopAtlanta.Data.Mapping;

namespace TopAtlanta.Data
{
    public partial class DBTopAtlantaContext : DataContext
    {
        static DBTopAtlantaContext()
        {
            Database.SetInitializer<DBTopAtlantaContext>(null);
        }

        public DBTopAtlantaContext()
            : base("Name=DBTopAtlantaContext")
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountGroup> AccountGroups { get; set; }
        public DbSet<AccountStatus> AccountStatuses { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<MemberAgent> MemberAgents { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<TimeFrame> TimeFrames { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AccountMap());
            modelBuilder.Configurations.Add(new AccountGroupMap());
            modelBuilder.Configurations.Add(new AccountStatusMap());
            modelBuilder.Configurations.Add(new AccountTypeMap());
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new AddressTypeMap());
            modelBuilder.Configurations.Add(new ContactMap());
            modelBuilder.Configurations.Add(new EmailAddressMap());
            modelBuilder.Configurations.Add(new GroupMap());
            modelBuilder.Configurations.Add(new MemberAgentMap());
            modelBuilder.Configurations.Add(new PhoneMap());
            modelBuilder.Configurations.Add(new PhoneTypeMap());
            modelBuilder.Configurations.Add(new TimeFrameMap());

        }
    }
}
