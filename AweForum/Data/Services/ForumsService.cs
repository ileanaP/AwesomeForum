using AweForum.Data.Base;
using AweForum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.Services
{
    public class ForumsService : ModelBaseRepository<Forum>, IForumsService
    {
        private AppDbContext _context;
        public ForumsService(AppDbContext context) : base(context) 
        {
            _context = context;
        }

        /*public async Task<List<Forum>> GetAllWithCategoryAsync()
        {
            var forums = await _context.Forums.Include(n => n.Category).ToListAsync();

            return forums;
        }*/
    }
}
