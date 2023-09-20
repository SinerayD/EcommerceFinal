using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Core.Entities
{
    public class Setting : BaseEntity
    {
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [NotMapped]
        public IFormFile? file { get; set; }
     
    }
}
