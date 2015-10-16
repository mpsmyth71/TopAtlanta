using Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopAtlanta.Service;
using TopAtlanta.Web.Models;

namespace TopAtlanta.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IContactService _contactService;
        private readonly IUnitOfWork _unitOfWork;

        public AccountController(IAccountService accountService, IContactService contactService, IUnitOfWork unitOfWork)
        {
            _accountService = accountService;
            _contactService = contactService;
            _unitOfWork = unitOfWork;
        }

        //
        // GET: /Account/
        public ActionResult Index()
        {
            var m = new AccountSearchVM() {Criteria = new AccountSearchCriteriaVM(), SelectedAccount = new AccountDetailVM(), List = new ResultList<AccountListVM>() };
            return View(m);
        }

        public PartialViewResult List(AccountSearchCriteriaVM criteria)
        {

            return PartialView();
        }

        public PartialViewResult Edit()
        {

            try
            {
                if (this.ModelState.IsValid)
                { 
                
                
                }
            }
            catch (Exception)
            {
                
                throw;
            }

            return PartialView();
        }

        public PartialViewResult Details()
        {
            return PartialView();
        }

        public PartialViewResult Create()
        {

            return PartialView("Edit", new AccountDetailVM());
        }

        public PartialViewResult Record()
        {
            return PartialView();
        }
	}
}