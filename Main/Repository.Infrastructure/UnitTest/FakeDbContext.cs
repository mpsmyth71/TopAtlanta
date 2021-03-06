﻿using Repository.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Infrastructure.UnitTest
{
    public interface IFakeDbContext : IDataContextAsync
    {
        DbSet<T> Set<T>() where T : class;

        void AddFakeDbSet<T, TFakeDbSet>()
            where T : EntityObjectState, new()
            where TFakeDbSet : FakeDbSet<T>, IDbSet<T>, new();
    }

    public abstract class FakeDbContext : IFakeDbContext
    {
        private readonly Dictionary<Type, object> _fakeDbSets;

        protected FakeDbContext()
        {
            _fakeDbSets = new Dictionary<Type, object>();
        }

        public int SaveChanges() { return default(int); }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken) { return new Task<int>(() => default(int)); }
        
        public Task<int> SaveChangesAsync() { return new Task<int>(() => default(int)); }

        public void SyncObjectState<T>(T entity) where T : class, IObjectState
        {
            // no implentation needed, unit tests which uses FakeDbContext since there is no actual database for unit tests, 
            // there is no actual DbContext to sync with, please look at the Integration Tests for test that will run against an actual database.
        }

        public void Dispose() { }

        public DbSet<T> Set<T>() where T : class { return (DbSet<T>)_fakeDbSets[typeof(T)]; }

        public void AddFakeDbSet<T, TFakeDbSet>()
            where T : EntityObjectState, new()
            where TFakeDbSet : FakeDbSet<T>, IDbSet<T>, new()
        {
            var fakeDbSet = Activator.CreateInstance<TFakeDbSet>();
            _fakeDbSets.Add(typeof(T), fakeDbSet);
        }

        public void SyncObjectsStatePostCommit() { }
    }
}

