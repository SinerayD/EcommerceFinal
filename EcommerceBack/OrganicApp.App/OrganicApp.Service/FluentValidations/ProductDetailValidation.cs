using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class ProductDetailValidation : AbstractValidator<ProductDetail>
    {
        public ProductDetailValidation()
        {
            RuleFor(x => x.ProductId).Must(x => x != 0).WithMessage("Select a product! If not available, add a new product.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Write Product Name").NotNull().WithMessage("Write Product Name")
                .Length(2, 1000).WithMessage("Product description should e between 2-1000 characters");

            RuleFor(x => x.Weight).NotNull().WithMessage("Enter the weight.");

            RuleFor(x => x.StarCount).NotNull().WithMessage("Add Product Count.");

            RuleFor(x => x.StarCount).Must(x => x != 0).WithMessage("Add Number");
        }
    }
}
