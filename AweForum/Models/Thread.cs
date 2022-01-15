using AweForum.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Models
{
    public class Thread : IModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreatorId { get; set; }
        [ForeignKey(nameof(CreatorId))]
        public AppUser Creator { get; set; }
        public int ForumId { get; set; }
        [ForeignKey(nameof(ForumId))]
        public Forum Forum { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastPosted { get; set; }
        public int MessageCount { get; set; }
    }
}
