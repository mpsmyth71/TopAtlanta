using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopAtlanta.Web.Models
{
    public class AccountSearchCriteriaVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }

        public string Filter { get; set; }
        public string Sort { get; set; }
        public bool SortDesc { get; set; }
    }
}