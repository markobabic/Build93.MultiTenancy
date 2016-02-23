using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Build93.MultiTenancy.Contracts;

namespace Build93.MultyTenancy.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContext _db;

        public UnitOfWork(ITenantProvider<int> contextProvider,DbContext baseContext)
        {
            _db = new DbContextWrapper(contextProvider,baseContext);
        }

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        public Task<int> CommitAsync()
        {
            return _db.SaveChangesAsync();
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            return _db.SaveChanges();
        }


        public void Dispose()
        {
            _db.Dispose();
        }


        public IDbSet<T> GetDbSet<T>() where T : class
        {
            return _db.Set<T>();
        }


        public DbEntityEntry Entry(object entity)
        {
            return _db.Entry(entity);
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return _db.Entry<TEntity>(entity);
        }
    }
}
