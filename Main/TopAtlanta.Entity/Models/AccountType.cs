using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public partial class AccountType
    {
        public AccountType()
        {
            this.Accounts = new List<Account>();
        }

        public int AccountTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public string UpdatedDate { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }
}
