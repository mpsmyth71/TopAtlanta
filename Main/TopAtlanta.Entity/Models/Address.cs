using System;
using System.Collections.Generic;

namespace TopAtlanta.Entities.Models
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int AddressTypeId { get; set; }
        public int ContactId { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsPrimary { get; set; }
        public System.DateTimeOffset CreateDate { get; set; }
        public System.DateTimeOffset CreatedBy { get; set; }
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
        public Nullable<System.DateTimeOffset> UpdatedBy { get; set; }
        public virtual AddressType AddressType { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
