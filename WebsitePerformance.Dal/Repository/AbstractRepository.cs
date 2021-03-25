using Microsoft.EntityFrameworkCore;
using WebsitePerformance.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebsitePerformance.Dal.Repository
{
    public abstract class AbstractRepository<TEntity> : IRepository<TEntity> where TEntity : class, IDbEntity
    {
        private protected WebsitePerformanceDbContext dbContext;

        protected AbstractRepository(WebsitePerformanceDbContext context)
        {
            dbContext = context;
        }

        public Task<IEnumerable<TEntity>> GetAllAsync(int skip, int top)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<int> CreateAsync(TEntity model)
        {
            if (model == null)
                throw new ArgumentNullException();

            await dbContext.Set<TEntity>().AddAsync(model);
            await dbContext.SaveChangesAsync();

            return model.Id;
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCountAsync()
        {
            throw new NotImplementedException();
        }
    }
}
    
