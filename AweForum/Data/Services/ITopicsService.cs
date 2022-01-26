using AweForum.Data.Base;
using AweForum.Data.ViewModels;
using AweForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.Services
{
    public interface ITopicsService : IModelBaseRepository<Topic>
    {
        public Task<NewTopicDropdownVM> GetNewTopicDropdownValues();
        public Task AddNewTopicAsync(NewTopicVM newThread, string userId);
    }
}
