using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Core.Entities
{
    public class Comment : BaseEntity
    {
        public string? Message { get; set; }
        public string? ByName { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
