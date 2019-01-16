using System.Collections.Generic;

namespace EntityFrameworkDemo.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        /// <summary>
        /// Implements the ToList() method with AsNoTracking() ! on the TEntity collection.
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Implements the Add() functionality of the Entity Framework Core.
        /// </summary>
        void Add(TEntity entity);

        /// <summary>
        /// Implements the AddRange() functionality of the Entity Framework Core.
        /// </summary>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Implements the Remove() method on EF core
        /// </summary>
        void Remove(TEntity entity);

        /// <summary>
        /// Implements the RemoveRange() method on EF core
        /// </summary>
        /// <param name="entities">
        /// TEntity parameter which is used for the method.
        /// </param>
        void RemoveRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Implements the Load() method on EF core.
        /// </summary>
        void Load();

        /// <summary>
        /// Removes all rows in a table.
        /// </summary>
        void Clear();

        /// <summary>
        /// Implements the Count() method on EF core.
        /// </summary>
        /// <returns></returns>
        int Count();
    }
}
