using AweForum.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Models
{
    public class Message_Reaction : IModelBase
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        [ForeignKey(nameof(MessageId))]
        public TopicMessage TopicMessage { get; set; }
        public int ReactionId { get; set; }
        [ForeignKey(nameof(ReactionId))]
        public Reaction Reaction { get; set; }
    }
}
