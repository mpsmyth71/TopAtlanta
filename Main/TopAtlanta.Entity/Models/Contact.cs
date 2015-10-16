using Repository.Infrastructure;
using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public class Contact : EntityObjectState
    {
        public Contact()
        {
            this.Accounts = new List<Account>();
            this.Addresses = new List<Address>();
            this.EmailAddresses = new List<EmailAddress>();
            this.Phones = new List<Phone>();
        }

        public int ContactId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string Notes { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
