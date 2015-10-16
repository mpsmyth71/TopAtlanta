using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopAtlanta.Web.Models
{
    public class AccountListVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public bool Selected { get; set; }

        public void FillBlank()
        {

            if (string.IsNullOrWhiteSpace(this.FirstName))
                this.FirstName = "(first)";

            if (string.IsNullOrWhiteSpace(this.LastName))
                this.LastName = "(last)";

            if (string.IsNullOrWhiteSpace(this.AddressLine))
                this.AddressLine = "(Address Line)";

            if (string.IsNullOrWhiteSpace(this.City))
                this.City = "(city)";

            if (string.IsNullOrWhiteSpace(this.State))
                this.State = "(state)";

            if (string.IsNullOrWhiteSpace(this.PostalCode))
                this.PostalCode = "(zip)";
        }
    }
}