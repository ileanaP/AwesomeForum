using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.ViewModels
{
    public class NewTopicVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Forum")]
        public int ForumId { get; set; }
        [Required(ErrorMessage = "Message is required")]
        [Display(Name = "Message")]
        public string MessageText { get; set; }
    }
}
