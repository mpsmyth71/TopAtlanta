using System;

namespace Repository.Infrastructure.Contract
{
    public interface IDataContext : IDisposable
    {
        int SaveChanges();
        void SyncObjectState<T>(T entity) where T : class, IObjectState;
        void SyncObjectsStatePostCommit();
    }
}
