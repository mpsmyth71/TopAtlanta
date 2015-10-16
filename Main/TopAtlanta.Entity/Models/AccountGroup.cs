using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public partial class AccountGroup
    {
        public int GroupId { get; set; }
        public int AccountId { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }
    }
}
