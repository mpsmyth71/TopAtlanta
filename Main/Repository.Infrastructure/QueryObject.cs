using System;
using LinqKit;
using System.Linq.Expressions;
using Repository.Infrastructure.Contract;


namespace Repository.Infrastructure
{
    public abstract class QueryObject<T> : IQueryObject<T>
    {
        private Expression<Func<T, bool>> _query;

        public virtual Expression<Func<T, bool>> Query()
        {
            return _query;
        }

        public Expression<Func<T, bool>> And(Expression<Func<T, bool>> query)
        {
            return _query = _query == null ? query : _query.And(query.Expand());
        }

        public Expression<Func<T, bool>> Or(Expression<Func<T, bool>> query)
        {
            return _query = _query == null ? query : _query.Or(query.Expand());
        }

        public Expression<Func<T, bool>> And(IQueryObject<T> queryObject)
        {
            return And(queryObject.Query());
        }

        public Expression<Func<T, bool>> Or(IQueryObject<T> queryObject)
        {
            return Or(queryObject.Query());
        }
    }
}