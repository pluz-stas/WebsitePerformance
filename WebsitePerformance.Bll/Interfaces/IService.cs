using WebsitePerformance.Dal.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebsitePerformance.Bll.Interfaces
{
    public interface IService<TModel, QEntity>
        where TModel : class, new()
        where QEntity : class, IDbEntity, new()
    {
        Task<IEnumerable<TModel>> GetAllAsync(int skip, int top);

        Task<TModel> GetByIdAsync(int id);

        Task<int> CreateAsync(TModel model);

        Task UpdateAsync(TModel model);

        Task DeleteAsync(int id);

        Task<int> GetCountAsync();
    }
}
