﻿using AweForum.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Models
{
    public class Reaction : IModelBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public List<User_Reaction> User_Reactions { get; set; }
        public List<Message_Reaction> Message_Reactions { get; set; }
    }
}
