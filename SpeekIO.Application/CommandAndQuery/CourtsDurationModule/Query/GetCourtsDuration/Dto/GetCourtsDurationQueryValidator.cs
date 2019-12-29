using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDuration.Dto
{
    public class GetCourtsDurationValidator : BaseValidator<GetCourtsDurationResponse>
    {
        public GetCourtsDurationValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Court duration id is missing.");
        }
    }
}
