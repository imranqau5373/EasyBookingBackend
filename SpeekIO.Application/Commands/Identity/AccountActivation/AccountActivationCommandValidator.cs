using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.AccountActivation
{
    public class AccountActivationCommandValidator : BaseValidator<AccountActivationCommand>
    {
        public AccountActivationCommandValidator()
        {
            RuleFor(t => t.ActivationToken).NotNull().NotEmpty().WithMessage("Activation token is missing");
            RuleFor(t => t.Email).NotNull().NotEmpty().WithMessage("Email is missing");
            RuleFor(t => t.Email).EmailAddress().WithMessage("Email is not in a valid format");
        }
    }
}
