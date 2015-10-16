using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public partial class EmailAddress
    {
        public int EmailAddressId { get; set; }
        public int ContactId { get; set; }
        public string Email { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsActive { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
