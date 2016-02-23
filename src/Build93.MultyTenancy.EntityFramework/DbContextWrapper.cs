using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Build93.MultiTenancy.Contracts;

namespace Build93.MultyTenancy.EntityFramework
{
    public class DbContextWrapper : IDbContext
    {
        private readonly DbContext _dbContext;
        private readonly ITenantProvider<int> _provider;
        private readonly Dictionary<Type, object> _sets;

        public DbContextWrapper(ITenantProvider<int> contextProvider, DbContext baseContext)
        {
            _dbContext = baseContext;
            _provider = contextProvider;
            _sets = new Dictionary<Type, object>();
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public DbEntityEntry Entry(object entity)
        {
            return _dbContext.Entry(entity);
        }

        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            return _dbContext.Entry(entity);
        }


        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            var type = typeof (TEntity);
            if (!_sets.ContainsKey(type))
            {
                lock (this)
                {
                    if (!_sets.ContainsKey(type))
                    {
                        var tenant = _provider.Current;

                        if (tenant == null)
                            throw new ArgumentNullException("Tenant Unknown");


                        if (type.GetInterfaces()
                            .Where(i => i.IsGenericType)
                            .Any(i => i.GetGenericTypeDefinition() == typeof (ITenantEntity<>)))
                            _sets.Add(type, GetFilteredDbSet<TEntity>(tenant));
                        else
                            _sets.Add(type, _dbContext.Set<TEntity>());

                    }
                }
            }
            return _sets[type] as IDbSet<TEntity>;
        }


        private IDbSet<TEntity> GetFilteredDbSet<TEntity>(ITenant<int> tenant)
            where TEntity : class
        {

            var paramExpr = Expression.Parameter(typeof (TEntity));
            var tidExpr = Expression.Property(paramExpr, "TenantId");
            var eqExpr = Expression.Equal(tidExpr, Expression.Constant(tenant.Id, typeof (int?)));

            return new FilteredDbSet<TEntity>(
                _dbContext,
                Expression.Lambda<Func<TEntity, bool>>(eqExpr, paramExpr),
                (entity) => { (entity as ITenantEntity<int>).TenantId = tenant.Id; }
                );
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
