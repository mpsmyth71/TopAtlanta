﻿using System.Threading;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Contract
{
    public interface IRepositoryAsync<T> : IRepository<T> where T : class, IObjectState
    {
        Task<T> FindAsync(params object[] keyValues);
        Task<T> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task<bool> DeleteAsync(params object[] keyValues);
        Task<bool> DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
    }
}
