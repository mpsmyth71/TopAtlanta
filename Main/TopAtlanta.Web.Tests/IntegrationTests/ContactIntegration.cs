using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Infrastructure.Contract;
using Repository.Infrastructure;
using TopAtlanta.Data;
using TopAtlanta.Service;
using TopAtlanta.Entities.Models;
using System.Linq;

namespace TopAtlanta.Tests.IntegrationTests
{
    [TestClass]
    public class ContactIntegration
    {
        [TestMethod]
        public void CreateContact()
        {
            int id = 0;

            using (IDataContextAsync db = new DBTopAtlantaContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWorkBase(db))
            {
                IContactService contactService = new ContactService(unitOfWork.RepositoryAsync<Contact>());

                var contact = new Contact
                {
                    FirstName = "Mike",
                    LastName = "Smyth",
                    Gender = "Male",
                    CreateDate = DateTime.Now,
                    CreatedBy = "test",
                };

                contactService.Insert(contact);
                id = unitOfWork.SaveChanges();
            }

            //Select
            using (IDataContextAsync db = new DBTopAtlantaContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWorkBase(db))
            {
                IContactService contactService = new ContactService(unitOfWork.RepositoryAsync<Contact>());
                var contact = contactService.GetContactByName("Mike", "Smyth").First();
                id = contact.ContactId;
                Assert.IsNotNull(contact);
            }

            //Update
            using (IDataContextAsync db = new DBTopAtlantaContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWorkBase(db))
            {
                IContactService contactService = new ContactService(unitOfWork.RepositoryAsync<Contact>());
                var contact = contactService.Find(id);

                contact.Birthday = DateTime.Parse("10/01/1971");
                contactService.Update(contact);
                unitOfWork.SaveChanges();

            }

            //Check and Delete
            using (IDataContextAsync db = new DBTopAtlantaContext())
            using (IUnitOfWorkAsync unitOfWork = new UnitOfWorkBase(db))
            {
                IContactService contactService = new ContactService(unitOfWork.RepositoryAsync<Contact>());
                var contact = contactService.Find(id);

                Assert.AreEqual(DateTime.Compare(DateTime.Parse(contact.Birthday.ToString()), DateTime.Parse("10/01/1971")),0);
                contactService.Delete(contact);
                unitOfWork.SaveChanges();

            }
        }
    }
}
