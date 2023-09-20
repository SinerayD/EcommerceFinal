using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Write product name.").NotNull().WithMessage("Write product name.")
                .Length(2, 100).WithMessage("Mehsul adi 2-100 simvol olmalidir.");

            RuleFor(x => x.Price).NotEmpty().WithMessage("Enter the price.");

            RuleFor(x => x.Photo).NotNull().WithMessage("Select a picture for the product...").NotEmpty().WithMessage("Select a picture for the product...");

            RuleFor(x => x.Count).NotNull().WithMessage("Enter the quantity of the product.");

            RuleFor(x => x.Count).Must(x => x != 0).WithMessage("Enter quantity.");
        }
    }
}
