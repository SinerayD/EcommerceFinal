﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Core.Entities
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile? Photo { get; set; }
        public List<Product>? Products { get; set; }
    }
}
