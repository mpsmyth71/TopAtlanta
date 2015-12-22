using Microsoft.VisualStudio.TestTools.UnitTesting;
using TopAtlanta.Tests.Fakes;
using Repository.Infrastructure.Contract;
using Repository.Infrastructure;
using TopAtlanta.Entities.Models;
using System.Linq;

namespace TopAtlanta.Tests.Service
{
    [TestClass]
    public class ContactUnitTest
    {
        [TestMethod]
        public void FindContactById()
        {
            using (IDataContextAsync fakeDbContext = new UnitTestFakeDbContext())
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(fakeDbContext))
            {
                unitOfWork.Repository<Contact>().Insert(new Contact { ContactId = 1, ObjectState = ObjectState.Added });
                unitOfWork.Repository<Contact>().Insert(new Contact { ContactId = 2, ObjectState = ObjectState.Added });
                unitOfWork.Repository<Contact>().Insert(new Contact { ContactId = 3, ObjectState = ObjectState.Added });

                unitOfWork.SaveChanges();

                var contact = unitOfWork.Repository<Contact>().Find(2);

                Assert.IsNotNull(contact);
                Assert.AreEqual(2, contact.ContactId);
            }
        }

        [TestMethod]
        public void DeleteContactById()
        {
            using (IDataContextAsync fakeDbContext = new UnitTestFakeDbContext())
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(fakeDbContext))
            {
                unitOfWork.Repository<Contact>().Insert(new Contact { ContactId = 1, ObjectState = ObjectState.Added });

                unitOfWork.SaveChanges();

                unitOfWork.Repository<Contact>().Delete(1);

                unitOfWork.SaveChanges();

                var contact = unitOfWork.Repository<Contact>().Find(1);

                Assert.IsNull(contact);
            }
        }

        //[TestMethod]
        //public void FindProductKeyAsync()
        //{
        //    using (IDataContextAsync fakeDbContext = new UnitTestFakeDbContext())
        //    using (IUnitOfWorkAsync unitOfWork = new UnitOfWorkBase(fakeDbContext))
        //    {
        //        unitOfWork.Repository<Contact>().Insert(new Contact { ContactId = 2 });

        //        unitOfWork.SaveChanges();

        //        var contact = unitOfWork.RepositoryAsync<Contact>().FindAsync(2);

        //        Assert.AreEqual(contact)
        //    }
        //}

        [TestMethod]
        public void DeleteContactByEntity()
        {
            using (IDataContextAsync fakeDbContext = new UnitTestFakeDbContext())
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(fakeDbContext))
            {
                unitOfWork.Repository<Contact>().Insert(new Contact { ContactId = 1, ObjectState = ObjectState.Added });

                unitOfWork.SaveChanges();

                var contact = unitOfWork.Repository<Contact>().Find(1);

                contact.ObjectState = ObjectState.Deleted;

                unitOfWork.Repository<Contact>().Delete(contact);

                unitOfWork.SaveChanges();

                var contactDeleted = unitOfWork.Repository<Contact>().Find(1);

                Assert.IsNull(contactDeleted);
            }
        }

        [TestMethod]
        public void InsertRangeOfContacts()
        {
            using (IDataContextAsync fakeDbContext = new UnitTestFakeDbContext())
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(fakeDbContext))
            {
                var newContacts = new[]
                {
                    new Contact {ContactId = 1, ObjectState = ObjectState.Added},
                    new Contact {ContactId = 2, ObjectState = ObjectState.Added},
                    new Contact {ContactId = 3, ObjectState = ObjectState.Added}
                };

                unitOfWork.Repository<Contact>().InsertRange(newContacts);

                var savedContacts = unitOfWork.Repository<Contact>().Query().Select();

                Assert.AreEqual(savedContacts.Count(), newContacts.Length);
            }
        }

        [TestMethod]
        public void UpdateContact()
        {
            using (IDataContextAsync fakeDbContext = new UnitTestFakeDbContext())
            using (IUnitOfWork unitOfWork = new UnitOfWorkBase(fakeDbContext))
            {
                unitOfWork.Repository<Contact>().Insert(new Contact { ContactId = 2, FirstName = "Steve", ObjectState = ObjectState.Added });

                unitOfWork.SaveChanges();

                var contact = unitOfWork.Repository<Contact>().Find(2);

                Assert.AreEqual(contact.FirstName, "Steve", "Assert we are able to find the inserted Contact.");

                contact.FirstName = "Mike";
                contact.ObjectState = ObjectState.Modified;

                unitOfWork.Repository<Contact>().Update(contact);
                unitOfWork.SaveChanges();

                Assert.AreEqual(contact.FirstName, "Mike", "Assert that our changes were saved.");
            }
        }

        
    }
}
