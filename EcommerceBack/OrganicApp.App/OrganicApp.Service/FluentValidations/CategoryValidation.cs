using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Write category name.").NotNull().WithMessage("Write category name.")
                .Length(2, 100).WithMessage("The category name must be 2-100 characters.");

            RuleFor(x => x.Photo).NotNull().WithMessage("Choose image for category...").NotEmpty().WithMessage("Choose image for category...");

           
        }
    }
}
