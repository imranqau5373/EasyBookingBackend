using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany.Dto
{
    public class AddCompanyCommandValidator : BaseValidator<AddCompanyCommand>
    {
        public AddCompanyCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Comapny name is missing.");
        }
    }
}
