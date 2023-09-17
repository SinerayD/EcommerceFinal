using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class AdvertValidation : AbstractValidator<Advert>
    {
        public AdvertValidation()
        {
            RuleFor(x => x.Photo).NotNull().WithMessage("Sekil secin...").NotEmpty().WithMessage("Sekil secin...");
        }
    }
}
