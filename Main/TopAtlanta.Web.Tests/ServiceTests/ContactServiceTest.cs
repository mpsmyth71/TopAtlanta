using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopAtlanta.Service;
using Repository.Infrastructure.Contract;
using TopAtlanta.Entities.Models;
using Repository.Infrastructure;
using TopAtlanta.Tests.Fakes;

namespace TopAtlanta.Tests.ServiceTests
{
    [TestClass]
    public class ContactServiceTest
    {
        [TestMethod]
        public void FindContactServiceById()
        {
            using (IDataContextAsync fakeDbContext = new UnitTestFakeDbContext())
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(fakeDbContext))
            {
                IContactService contactService = new ContactService(unitOfWork.Repository<Contact>());

                contactService.Insert(new Contact { ContactId = 1, ObjectState = ObjectState.Added });
                unitOfWork.SaveChanges();

                var contact = contactService.Find(1);
                Assert.IsNotNull(contact);
                Assert.AreEqual(1, contact.ContactId);
            }
        }
    }
}
