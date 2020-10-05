using System.Collections.Generic;
using System.Threading.Tasks;

namespace MicroserviceDemo.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IEnumerable<TEntity> FindAll();
        Task<bool> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

    }    
}

