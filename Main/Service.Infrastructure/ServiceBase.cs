using Repository.Infrastructure;
using Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Service.Infrastructure
{
    public abstract class Service<T> : IService<T> where T : class, IObjectState
    {
        private readonly IRepository<T> _repository;

        protected Service(IRepository<T> repository) { _repository = repository; }

        public virtual T Find(params object[] keyValues) { return _repository.Find(keyValues); }

        public T GetById(object id) { return _repository.GetById(id); }

        public virtual IQueryable<T> SelectQuery(string query, params object[] parameters) { return _repository.SelectQuery(query, parameters).AsQueryable(); }

        public virtual void Insert(T entity) { _repository.Insert(entity); }

        public virtual void InsertRange(IEnumerable<T> entities) { _repository.InsertRange(entities); }

        public virtual void InsertOrUpdateGraph(T entity) { _repository.InsertOrUpdateGraph(entity); }

        public virtual void InsertGraphRange(IEnumerable<T> entities) { _repository.InsertGraphRange(entities); }

        public virtual void Update(T entity) { _repository.Update(entity); }

        public virtual void Delete(object id) { _repository.Delete(id); }

        public virtual void Delete(T entity) { _repository.Delete(entity); }

        public IQueryFluent<T> Query() { return _repository.Query(); }

        public virtual IQueryFluent<T> Query(IQueryObject<T> queryObject) { return _repository.Query(queryObject); }

        public virtual IQueryFluent<T> Query(Expression<Func<T, bool>> query) { return _repository.Query(query); }

        public IQueryable<T> Queryable() { return _repository.Queryable(); }



    }
}
