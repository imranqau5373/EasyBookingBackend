using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.SignIn
{
    public class SignInCommandValidator : BaseValidator<SignInCommand>
    {
        public SignInCommandValidator()
        {
            RuleFor(t => t.Email).NotNull().NotEmpty().WithMessage("Email is missing");
            RuleFor(t => t.Email).EmailAddress().WithMessage("Email is not in a valid format");
            RuleFor(t => t.Password).NotNull().NotEmpty().WithMessage("Password is missing");
        }
    }
}
