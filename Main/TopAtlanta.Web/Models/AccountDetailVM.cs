using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TopAtlanta.Web.Models
{
    public class AccountDetailVM
    {
        //Account Information
        public int AccountId { get; set; }

        //Contact Information
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public DateTime Birthday { get; set;}


        public string Email { get; set; }



        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTimeOffset UpdatedDate { get; set; }
    }
}