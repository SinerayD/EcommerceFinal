using FluentValidation;
using FluentValidation.Validators;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Write Email.").NotNull().WithMessage("Write Email.")
                .Length(2, 150).WithMessage("It must be 2-150 characters.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Adini yazin.").NotNull().WithMessage("Write Name.")
                .Length(2, 150).WithMessage("It must be 2-150 characters.");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Message yazin.").NotNull().WithMessage("Write Name.")
                .Length(2, 300).WithMessage("It must be 2-100 characters.");
        }
    }
}
