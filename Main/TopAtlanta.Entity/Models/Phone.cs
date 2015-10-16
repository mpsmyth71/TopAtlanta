using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public partial class Phone
    {
        public int PhoneId { get; set; }
        public int ContactId { get; set; }
        public int PhoneTypeId { get; set; }
        public string Number { get; set; }
        public string Extension { get; set; }
        public bool IsPrimary { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual PhoneType PhoneType { get; set; }
    }
}
