using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.SignUp
{
    public class SignupCommandValidator : BaseValidator<SignupCommand>
    {
        public SignupCommandValidator()
        {
            RuleFor(t => t.CompanyName).NotNull().NotEmpty().WithMessage("CompanyName is missing");
            RuleFor(t => t.FirstName).NotNull().NotEmpty().WithMessage("First Name is missing");
            RuleFor(t => t.LastName).NotNull().NotEmpty().WithMessage("Last Name is missing");
            RuleFor(t => t.CompanyPrivateUrl).NotNull().NotEmpty().WithMessage("CompanyPrivateUrl is missing");
            RuleFor(t => t.CompanyPrivateUrl).Must((t) => ValidateUrl(t)).WithMessage("CompanyPrivateUrl is not in a valid format");
            //RuleFor(t => t.ContactName).NotNull().NotEmpty().WithMessage("ContactName is missing");
            RuleFor(t => t.Email).NotNull().NotEmpty().WithMessage("Email is missing");
            RuleFor(t => t.Email).EmailAddress().WithMessage("Email is not in a valid format");
            RuleFor(t => t.Phone).NotNull().NotEmpty().WithMessage("Phone is missing");
            RuleFor(t => t.Phone).Must(t => ValidatePhone(t)).WithMessage("Phone is not in a valid format");
            RuleFor(t => t.Password).NotNull().NotEmpty().WithMessage("Password is missing");
            RuleFor(t => t.ConfirmPassword).NotNull().NotEmpty().WithMessage("ConfirmPassword is missing");
            RuleFor(t => t.Password).Must(t => PasswordValidation(t)).WithMessage("Password do not match the criteria");
            RuleFor(t => t).Must(t => t.Password == t.ConfirmPassword).WithMessage("Password and ConfirmPassword donot match");
        }
    }
}
