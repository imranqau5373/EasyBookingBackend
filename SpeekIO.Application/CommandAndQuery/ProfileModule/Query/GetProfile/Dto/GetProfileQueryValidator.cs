using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Query.GetProfile.Dto
{
    public class GetProfileQueryValidator : BaseValidator<GetProfileQuery>
    {
        public GetProfileQueryValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Profile id is missing.");
        }
    }
}
