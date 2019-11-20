using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepTwo
{
    public class ForgetPasswordStepTwoCommandValidator : BaseValidator<ForgetPasswordStepTwoCommand>
    {
        public ForgetPasswordStepTwoCommandValidator()
        {
            RuleFor(t => t.Email).NotNull().NotEmpty().WithMessage("Email is missing");
            RuleFor(t => t.ResetToken).NotNull().NotEmpty().WithMessage("ResetToken is missing");
            RuleFor(t => t.NewPassword).NotNull().NotEmpty().WithMessage("NewPassword is missing");
            RuleFor(t => t.NewPassword).Must(t => PasswordValidation(t)).WithMessage("Password do not meet the requirements");
        }
    }
}
