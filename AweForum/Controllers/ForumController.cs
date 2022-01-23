using AweForum.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Controllers
{
    public class ForumController : Controller
    {
        private IForumsService _forumService;

        public ForumController(IForumsService forumService)
        {
            _forumService = forumService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var forum = await _forumService.GetByIdWithThreadsAsync(id);
            return View(forum);
        }
    }
}
