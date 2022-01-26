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

        public async Task<Forum> GetByIdWithTopicAsync(int id)
        {
            var forum = await _context.Forums.Include(f => f.Topics)
                .FirstOrDefaultAsync(f => f.Id == id);

            return forum;
        }
    }
}
