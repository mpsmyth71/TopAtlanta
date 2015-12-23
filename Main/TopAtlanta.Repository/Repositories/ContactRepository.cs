using Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Repository.Repositories
{
    public static class ContactRepository
    {
        public static IEnumerable<Contact> GetContactByName(this IRepositoryAsync<Contact> repository, string firstname, string lastname)
        {
            return repository
                .Queryable()
                .Where(x => x.FirstName.StartsWith(firstname) && x.LastName.StartsWith(lastname))               
                .AsEnumerable();
        }
    }
}
