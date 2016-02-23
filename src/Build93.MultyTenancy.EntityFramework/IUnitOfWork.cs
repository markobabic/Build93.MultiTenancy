using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build93.MultyTenancy.EntityFramework
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Commits the asynchronous.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        int Commit();


        /// <summary>
        /// Gets the database set.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class;




        //TODO: find way to abstract from EF
        DbEntityEntry Entry(object entity);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

    }
}
