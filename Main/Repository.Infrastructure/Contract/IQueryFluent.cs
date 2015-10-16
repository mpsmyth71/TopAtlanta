using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Repository.Infrastructure.Contract
{
    public interface IQueryFluent<T> where T : IObjectState
    {
        IQueryFluent<T> OrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        IQueryFluent<T> Include(Expression<Func<T, object>> expression);
        IEnumerable<T> SelectPage(int page, int pageSize, out int totalCount);
        IEnumerable<TResult> Select<TResult>(Expression<Func<T, TResult>> selector = null);
        IEnumerable<T> Select();
        IQueryable<T> SqlQuery(string query, params object[] parameters);
    }
}