using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteSports.Dto
{
    public class DeleteSportsCommandValidator : BaseValidator<DeleteSportsCommand>
    {
        public DeleteSportsCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Please provide valid Identifier.");
        }
    }
}
