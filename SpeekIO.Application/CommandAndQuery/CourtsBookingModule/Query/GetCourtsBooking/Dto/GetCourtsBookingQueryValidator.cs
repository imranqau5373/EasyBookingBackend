using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBooking.Dto
{
    public class GetCourtsBookingValidator : BaseValidator<GetCourtsBookingQuery>
    {
        public GetCourtsBookingValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Booking id is missing.");
        }
    }
}
