﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Core.Entities
{
    public class BlogDetail : BaseEntity
    {
        public string? Description { get; set; }
        public string? CategoryName { get; set; }
        public string? Tags { get; set; }

        public int BlogId { get; set; }

        public Blog? Blog { get; set; }
    }
}
