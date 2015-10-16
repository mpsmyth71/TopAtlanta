using Repository.Infrastructure;
using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public class Account : EntityObjectState
    {
        public Account()
        {
            this.AccountGroups = new List<AccountGroup>();
        }

        public int AccountId { get; set; }
        public int ContactId { get; set; }
        public int AccountTypeId { get; set; }
        public int AccountStatusesId { get; set; }
        public Nullable<int> TimeFrameId { get; set; }
        public Nullable<int> MemberAgentId { get; set; }
        public string Source { get; set; }
        public string Notes { get; set; }
        public string Referral { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual AccountStatus AccountStatus { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual MemberAgent MemberAgent { get; set; }
        public virtual TimeFrame TimeFrame { get; set; }
        public virtual ICollection<AccountGroup> AccountGroups { get; set; }
    }
}
