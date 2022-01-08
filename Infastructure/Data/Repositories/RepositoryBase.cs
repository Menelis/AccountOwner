using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces.Gateways.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;

namespace Infastructure.Data.Repositories
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : class
    {
        protected readonly AccountOwnerDbContext _dbContext;
        private readonly DbSet<T> Table;

        protected RepositoryBase(AccountOwnerDbContext dbContext)
        {
            _dbContext = dbContext;
            Table = _dbContext.Set<T>();
        }
        public async Task<T> Add(T entity)
        {
            Table.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(T entity)
        {
            Table.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(object id)
        {
            return await Table.FindAsync(id);
        }
        public async Task<T> GetSingleBySpec(Expression<Func<T, bool>> where)
        {
            var query = await List(where);
            return query.FirstOrDefault();
        }      

        public async Task<List<T>> List(Expression<Func<T, bool>> where)
        {
            IQueryable<T> query = Table.Where(where);
            return await query.ToListAsync();
        }

        public async Task<List<T>> ListAll()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> Update(T entity, object key)
        {
            var entitytoUpdate = await Table.FindAsync(key);
            if(entitytoUpdate is not null)
            {
                _dbContext.Entry(entitytoUpdate).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }
    }
}