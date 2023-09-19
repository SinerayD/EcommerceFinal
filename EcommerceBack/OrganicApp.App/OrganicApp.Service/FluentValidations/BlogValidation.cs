﻿using FluentValidation;
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
            RuleFor(x => x.Title).NotEmpty().WithMessage("Mehsul'un adini yazin.").NotNull().WithMessage("Mehsul'un adini yazin.")
                .Length(2, 100).WithMessage("Mehsul adi 2-500 simvol olmalidir.");

            RuleFor(x => x.Photo).NotNull().WithMessage("Mehsul ucun sekil secin...").NotEmpty().WithMessage("Mehsul ucun sekil secin...");
        }
    }
}
