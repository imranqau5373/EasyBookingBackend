using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.UpdateProfile
{
    public class UpdateProfileValidator : BaseValidator<UpdateProfileCommand>
    {
        public UpdateProfileValidator()
        {
            RuleFor(t => t.CompanyName).NotEmpty().WithMessage("Company name is missing");
            RuleFor(t => t.Email).NotEmpty().WithMessage("Email address is missing");
        }
    }
}
