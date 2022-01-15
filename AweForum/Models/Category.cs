using AweForum.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Models
{
    public class Category : IModelBase
    {
        [Key]
        public int Id { get; set;  }
        public string Name { get; set; }
        public int OrderNr { get; set; }
        public List<Message_Reaction> Message_Reactions { get; set; }
    }
}
