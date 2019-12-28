using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.DeleteCourtsBooking.Dto
{
    public class DeleteCourtsBookingCommandValidator : BaseValidator<DeleteCourtsBookingCommand>
    {
        public DeleteCourtsBookingCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Please provide valid Identifier.");
        }
    }
}
