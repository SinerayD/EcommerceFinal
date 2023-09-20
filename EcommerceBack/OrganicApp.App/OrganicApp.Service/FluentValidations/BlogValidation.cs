using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Write product name.").NotNull().WithMessage("Write product name.")
                .Length(2, 100).WithMessage("The product name must be 2-500 characters.");

            RuleFor(x => x.Photo).NotNull().WithMessage("Choose image for product...").NotEmpty().WithMessage("Choose image for product...");
        }
    }
}
