using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Infrastructure.Contract
{
    public interface IRepository<T> where T : class, IObjectState
    {
        
        T Find(params object[] keyValues);
        IQueryable<T> SelectQuery(string query, params object[] parameters);
        IQueryable<T> Queryable();
        T GetById(object id);

        IQueryFluent<T> Query(IQueryObject<T> queryObject);
        IQueryFluent<T> Query(Expression<Func<T, bool>> query);
        IQueryFluent<T> Query();

        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void InsertOrUpdateGraph(T entity);
        void InsertGraphRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);

        IRepository<T> GetRepository<T>() where T : class, IObjectState;
    }
}
