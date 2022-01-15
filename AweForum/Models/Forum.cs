﻿using AweForum.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Models
{
    public class Forum : IModelBase
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int ThreadCount { get; set; }
        public int OrderNr { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
    }
}