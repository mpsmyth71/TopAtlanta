using Repository.Infrastructure.UnitTest;
using System;
using TopAtlanta.Entities.Models;

namespace TopAtlanta.Tests.Fakes
{
    public class UnitTestFakeDbContext : FakeDbContext
    {
        public UnitTestFakeDbContext()
        {
            AddFakeDbSet<Contact, ContactDbSet>();
        }
    }
}
