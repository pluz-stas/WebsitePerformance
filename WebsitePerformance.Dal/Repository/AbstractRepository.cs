using Microsoft.EntityFrameworkCore;
using WebsitePerformance.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(int skip, int top) => 
            await dbContext.Set<TEntity>()
                .Skip(skip)
                .Take(top)
                .AsNoTracking()
                .ToListAsync();
        
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => 
            await dbContext.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();

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

        public virtual async Task<TEntity> GetByIdAsync(int id) => 
            await dbContext.Set<TEntity>().FindAsync(id) ??
            throw new ArgumentNullException(nameof(TEntity));


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
    
