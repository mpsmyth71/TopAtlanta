using Repository.Infrastructure.Contract;
using Service.Infrastructure;
using System;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Service
{
    public interface IAccountService : IService<Account> { }

    public class AccountService : Service<Account>, IAccountService
    {
        private readonly IRepository<Account> _repository;

        public AccountService(IRepository<Account> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}