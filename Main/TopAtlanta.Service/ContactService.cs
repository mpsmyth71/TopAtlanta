using Repository.Infrastructure.Contract;
using Service.Infrastructure;
using System.Collections.Generic;
using TopAtlanta.Entities.Models;
using TopAtlanta.Repository.Repositories;

namespace TopAtlanta.Service
{
    public interface IContactService : IService<Contact>
    {

        IEnumerable<Contact> GetContactByName(string firstName, string lastName);

    }

    public class ContactService : Service<Contact>, IContactService
    {
        private readonly IRepositoryAsync<Contact> _repository;

        public ContactService(IRepositoryAsync<Contact> repository)
            : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Contact> GetContactByName(string firstName, string lastName)
        {
            return _repository.GetContactByName(firstName, lastName);
        }
    }
}
