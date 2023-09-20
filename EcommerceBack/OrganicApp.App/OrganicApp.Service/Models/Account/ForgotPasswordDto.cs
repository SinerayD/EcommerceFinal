using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.Models.Account
{
    public class ForgotPasswordDto
    {
        [EmailAddress(ErrorMessage = "Enter text in email format (with '@').")]
        public string? Email { get; set; }
    }
}
