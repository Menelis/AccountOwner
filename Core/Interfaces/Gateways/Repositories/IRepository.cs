using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces.Gateways.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns items by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetById(object id);
        /// <summary>
        /// Returns all items
        /// </summary>
        /// <returns></returns>         
        Task<List<T>> ListAll();
        /// <summary>
        /// Return single item by specifierd criteria
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<T> GetSingleBySpec(Expression<Func<T, bool>> where);
        /// <summary>
        /// Returns a list by specified condition
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Task<List<T>> List(Expression<Func<T, bool>> where);
        /// <summary>
        /// Create a new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Add(T entity);
        /// <summary>
        /// Modifies the existing item
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<T> Update(T entity, object key);
        /// <summary>
        /// Removes the existing entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task Delete(T entity);


    }
}