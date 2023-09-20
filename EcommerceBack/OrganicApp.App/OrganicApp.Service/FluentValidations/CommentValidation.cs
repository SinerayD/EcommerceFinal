using FluentValidation;
using OrganicApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicApp.Service.FluentValidations
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.ByName).NotEmpty().WithMessage("Write Name.").NotNull().WithMessage("Write Name.")
                .Length(2, 100).WithMessage("The name must be 2-100 characters.");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Message'un adini yazin.").NotNull().WithMessage("Message'un adini yazin.")
                .Length(2, 200).WithMessage("The message name must be 2-200 characters.");
        }
    }
}
