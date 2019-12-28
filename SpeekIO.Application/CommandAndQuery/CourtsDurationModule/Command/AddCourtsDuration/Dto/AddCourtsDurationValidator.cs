using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration.Dto
{
    public class AddCourtsDurationValidator : BaseValidator<AddCourtsDurationCommand>
    {
        public AddCourtsDurationValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Court name is missing.");
        }
    }
}
