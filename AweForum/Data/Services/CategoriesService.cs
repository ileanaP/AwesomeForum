using AweForum.Data.Base;
using AweForum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.Services
{
    public class CategoriesService : ModelBaseRepository<Category>, ICategoriesService
    {
        AppDbContext _context;
        public CategoriesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllWithCategoryAsync()
        {
            var categories = await _context.Categories.Include(n => n.Forums).ToListAsync();
            return categories;
        }
    }
}
