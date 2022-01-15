using AweForum.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Models
{
    public class ThreadMessage : IModelBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        public int ThreadId { get; set; }
        [ForeignKey(nameof(ThreadId))]
        public Thread Thread { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEditedDate { get; set; }
        public List<Message_Reaction> Message_Reactions { get; set; }
        public List<User_Reaction> User_Reactions { get; set; }
    }
}
