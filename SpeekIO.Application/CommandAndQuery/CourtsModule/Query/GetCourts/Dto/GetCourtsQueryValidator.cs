using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourts.Dto
{
    public class GetCourtsQueryValidator : BaseValidator<GetCourtsQuery>
    {
        public GetCourtsQueryValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Court id is missing.");
        }
    }
}
