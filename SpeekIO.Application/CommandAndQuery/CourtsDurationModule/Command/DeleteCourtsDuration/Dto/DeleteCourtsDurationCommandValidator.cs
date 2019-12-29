using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.DeleteCourtsDuration.Dto
{
    public class DeleteCourtsBookingCommandValidator : BaseValidator<DeleteCourtsDurationCommand>
    {
        public DeleteCourtsBookingCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Please provide valid Identifier.");
        }
    }
}
