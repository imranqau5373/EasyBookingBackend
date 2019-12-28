using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking.Dto
{
    public class AddCourtsBookingValidator : BaseValidator<AddCourtsBookingCommand>
    {
        public AddCourtsBookingValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage("Court name is missing.");
        }
    }
}
