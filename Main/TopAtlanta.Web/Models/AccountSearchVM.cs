using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Web.Models
{
    public class AccountSearchVM
    {
        public AccountSearchCriteriaVM Criteria { get; set; }
        public AccountDetailVM SelectedAccount { get; set; }
        public ResultList<AccountListVM> List { get; set; }
    }
}