using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace Build93.MultyTenancy.EntityFramework
{
    public interface IDbContext :IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
        IDbSet<T> Set<T>() where T : class;

        //TODO: find way to abstract from EF
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
