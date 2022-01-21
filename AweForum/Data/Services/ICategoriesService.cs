using AweForum.Data.Base;
using AweForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.Services
{
    public interface ICategoriesService : IModelBaseRepository<Category>
    {
        Task<List<Category>> GetAllWithCategoryAsync();
    }
}
