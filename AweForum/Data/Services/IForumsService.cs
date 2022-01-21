using AweForum.Data.Base;
using AweForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.Services
{
    public interface IForumsService : IModelBaseRepository<Forum>
    {
        /*Task<List<Forum>> GetAllWithCategoryAsync();*/
    }
}
