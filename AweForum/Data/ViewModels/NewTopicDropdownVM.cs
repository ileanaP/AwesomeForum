using AweForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data.ViewModels
{
    public class NewTopicDropdownVM
    {
        public NewTopicDropdownVM()
        {
            Forums = new List<Forum>();
        }
        public List<Forum> Forums { get; set; }
    }
}
