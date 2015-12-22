using Repository.Infrastructure.UnitTest;
using System;
using System.Linq;
using TopAtlanta.Entities.Models;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace TopAtlanta.Tests.Fakes
{
    public class ContactDbSet : FakeDbSet<Contact>
    {
        public override Contact Find(params object[] keyValues)
        {
            return this.SingleOrDefault(t => t.ContactId == (int)keyValues.FirstOrDefault());
        }

        public override Contact Add(Contact entity)
        {
            return base.Add(entity);
        }

        public override Contact Remove(Contact entity)
        {
            return base.Remove(entity);
        }

        public override DbSqlQuery<Contact> SqlQuery(string sql, params object[] parameters)
        {
            return base.SqlQuery(sql, parameters);
        }

        public override Task<Contact> FindAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            return base.FindAsync(cancellationToken, keyValues);
        }
    }



}
