using AweForum.Data.Base;
using AweForum.Data.ViewModels;
using AweForum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.Services
{
    public class TopicsService : ModelBaseRepository<Topic>, ITopicsService
    {
        AppDbContext _context;

        public TopicsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<NewTopicDropdownVM> GetNewTopicDropdownValues()
        {
            var forums = await _context.Forums.OrderBy(f => f.OrderNr)
                .OrderBy(f => f.CategoryId).ToListAsync();

            return new NewTopicDropdownVM() {
                Forums = forums
            };
        }

        public async Task AddNewTopicAsync(NewTopicVM newTopic, string userId)
        {
            var topic = new Topic()
            {
                Name = newTopic.Name,
                CreatorId = userId,
                ForumId = newTopic.ForumId,
                Active = true
            };

            await _context.Topics.AddAsync(topic);
            await _context.SaveChangesAsync();

            var message = new TopicMessage()
            {
                MessageText = newTopic.MessageText,
                UserId = userId,
                TopicId = topic.Id
            };

            await _context.TopicMessages.AddAsync(message);
            await _context.SaveChangesAsync();

            var forum = await _context.Forums.FirstOrDefaultAsync(f => f.Id == newTopic.ForumId);
            forum.TopicCount++;
            await _context.SaveChangesAsync();
        }
    }
}
