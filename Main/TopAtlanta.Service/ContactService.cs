using Repository.Infrastructure.Contract;
using Service.Infrastructure;
using System;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Service
{
    public interface IContactService : IService<Contact> { }

    public class ContactService : Service<Contact>, IContactService
    {
        private readonly IRepository<Contact> _repository;

        public ContactService(IRepository<Contact> repository)
            : base(repository)
        {
            _repository = repository;
        }
    }
}
