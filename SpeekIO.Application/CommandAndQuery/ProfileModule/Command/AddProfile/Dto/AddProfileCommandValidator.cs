using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.AddProfile.Dto
{
    public class AddProfileCommandValidator : BaseValidator<AddProfileCommand>
    {
        public AddProfileCommandValidator()
        {
            RuleFor(t => t.FirstName).NotEmpty().WithMessage("FirstName is missing.");
            RuleFor(t => t.LastName).NotEmpty().WithMessage("LastName is missing.");
            RuleFor(t => t.Email).NotEmpty().WithMessage("Email is missing.");
        }
    }
}
