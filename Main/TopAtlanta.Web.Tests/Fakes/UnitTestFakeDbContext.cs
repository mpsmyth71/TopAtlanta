using Repository.Infrastructure.UnitTest;
using System;



namespace TopAtlanta.Tests.Fakes
{
    public class UnitTestFakeDbContext : FakeDbContext
    {
        public UnitTestFakeDbContext()
        {
            //AddFakeDbSet<Login, LoginDbSet>();
        }
    }
}
