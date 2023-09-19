using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class BlogDetailValidator : AbstractValidator<BlogDetail>
    {
        public BlogDetailValidator()
        {
            RuleFor(x => x.BlogId).Must(x => x != 0).WithMessage("Select a Blog! If not available, add a new blog.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Write Name.").NotNull().WithMessage("Write Name.")
                .Length(2, 3000).WithMessage("It should be 2-3000 characters.");

            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Adini yazin.").NotNull().WithMessage("Write Name.")
                .Length(2, 500).WithMessage("It should be 2-500 characters.");

            RuleFor(x => x.Tags).NotEmpty().WithMessage("Write Name.").NotNull().WithMessage("Write Name.")
                .Length(2, 100).WithMessage("It should be 2-100 characters.");
        }
    }
}
