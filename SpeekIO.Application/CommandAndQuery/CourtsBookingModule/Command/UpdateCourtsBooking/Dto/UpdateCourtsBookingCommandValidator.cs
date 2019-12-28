using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking.Dto
{
    public class UpdateCourtsBookingCommandValidator : BaseValidator<UpdateCourtsBookingCommand>
    {
        public UpdateCourtsBookingCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage(" name is missing.");
        }
    }
}
