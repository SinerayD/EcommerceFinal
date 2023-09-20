using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class OwnerValidation : AbstractValidator<Owner>
    {
        public OwnerValidation()
        {
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("Write Name.").NotNull().WithMessage("Write Name.")
                .Length(2, 100).WithMessage("It must be 2-100 characters.");

            RuleFor(x => x.Profession).NotEmpty().WithMessage("Write Profession.").NotNull().WithMessage("Write Profession.")
                .Length(2, 100).WithMessage("It must be 2-100 characters.");

            RuleFor(x => x.Photo).NotNull().WithMessage("Choose Picture...").NotEmpty().WithMessage("Choose Picture...");
        }
    }
}
