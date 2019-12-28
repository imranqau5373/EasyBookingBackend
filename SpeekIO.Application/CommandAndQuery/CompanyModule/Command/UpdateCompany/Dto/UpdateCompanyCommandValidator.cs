using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto
{
    public class UpdateCompanyCommandValidator : BaseValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Comapny name is missing.");
        }
    }
}
