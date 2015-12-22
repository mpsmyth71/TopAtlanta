using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Infrastructure.Contract;
using Repository.Infrastructure;
using TopAtlanta.Data;
using TopAtlanta.Service;
using TopAtlanta.Entities.Models;

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
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(db))
            {
                IContactService contactService = new ContactService(unitOfWork.Repository<Contact>());

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

            using (IDataContextAsync db = new DBTopAtlantaContext())
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(db))
            {
                IContactService contactService = new ContactService(unitOfWork.Repository<Contact>());
                var contact = contactService.Find(id);
                Assert.IsNotNull(contact);
            }
        }
    }
}
