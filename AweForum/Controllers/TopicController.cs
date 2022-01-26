using AweForum.Data.Services;
using AweForum.Data.ViewModels;
using AweForum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AweForum.Controllers
{
    public class TopicController : Controller
    {
        private ITopicsService _topicsService;

        public TopicController(ITopicsService topicsService)
        {
            _topicsService = topicsService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var topicDropdownData = await _topicsService.GetNewTopicDropdownValues();
            ViewBag.Forums = new SelectList(topicDropdownData.Forums, "Id", "Name", id.ToString());

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewTopicVM newTopic)
        {
            if (!ModelState.IsValid)
            {
                var topicDropdownData = await _topicsService.GetNewTopicDropdownValues();
                ViewBag.Forums = new SelectList(topicDropdownData.Forums, "Id", "Name", newTopic.ForumId.ToString());
                
                return View(newTopic);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _topicsService.AddNewTopicAsync(newTopic, userId);

            return View();
        }
    }
}
