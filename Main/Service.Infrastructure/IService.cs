using Repository.Infrastructure;
using Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service.Infrastructure
{
    public interface IService<T> where T : IObjectState
    {
     
        T Find(params object[] keyValues);
        IQueryable<T> SelectQuery(string query, params object[] parameters);
        T GetById(object id);
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void InsertOrUpdateGraph(T entity);
        void InsertGraphRange(IEnumerable<T> entities);
        void Update(T entity);
        void Delete(T entity);
        void Delete(object id);

        IQueryFluent<T> Query();
        IQueryFluent<T> Query(IQueryObject<T> queryObject);
        IQueryFluent<T> Query(Expression<Func<T, bool>> query);
        IQueryable<T> Queryable();

    }
}
