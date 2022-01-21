using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AweForum.Data.Base
{
    public class ModelBaseRepository<T> : IModelBaseRepository<T> where T : class, IModelBase, new()
    {
        private AppDbContext _context;
        public ModelBaseRepository(AppDbContext context)
        {
            _context = context;
        }
        Task IModelBaseRepository<T>.AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        Task IModelBaseRepository<T>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IModelBaseRepository<T>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IModelBaseRepository<T>.GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        Task<T> IModelBaseRepository<T>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IModelBaseRepository<T>.UpdateAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
