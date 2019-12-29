using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteCompany.Dto
{
    public class DeleteCompanyCommandValidator : BaseValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Please provide valid Identifier.");
        }
    }
}
