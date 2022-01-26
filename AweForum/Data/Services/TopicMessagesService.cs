using AweForum.Data.Base;
using AweForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.Services
{
    public class TopicMessagesService : ModelBaseRepository<TopicMessage>, ITopicMessagesService
    {
        private AppDbContext _context;

        public TopicMessagesService(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
