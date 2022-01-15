using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AweForum.Data.Base
{
    public interface IModelBaseRepository<T> where T: class, IModelBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(int id, T entity);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
    }
}
