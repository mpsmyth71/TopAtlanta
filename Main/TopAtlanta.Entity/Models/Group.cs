using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public partial class Group
    {
        public Group()
        {
            this.AccountGroups = new List<AccountGroup>();
        }

        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual ICollection<AccountGroup> AccountGroups { get; set; }
    }
}
