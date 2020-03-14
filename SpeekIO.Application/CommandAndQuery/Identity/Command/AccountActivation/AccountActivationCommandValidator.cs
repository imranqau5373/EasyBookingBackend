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
			RuleFor(t => t.FirstName).NotEmpty().WithMessage("First name is missing");
			RuleFor(t => t.LastName).NotEmpty().WithMessage("Last name is missing");
			RuleFor(t => t.Password).NotEmpty().WithMessage("Password is missing");
			RuleFor(t => t.ConfirmPassword).NotEmpty().WithMessage("Confirm password is missing");
			RuleFor(t => t.Token).NotEmpty().WithMessage("Activation token is missing");
			RuleFor(t => t.Email).NotEmpty().WithMessage("Email is missing");
			RuleFor(t => t.Email).EmailAddress().WithMessage("Email is not in a valid format");
		}
    }
}
