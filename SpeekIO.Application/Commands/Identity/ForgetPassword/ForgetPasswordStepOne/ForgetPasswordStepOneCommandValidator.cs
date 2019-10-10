using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Identity.ForgetPassword.ForgetPasswordStepOne
{
    public class ForgetPasswordStepOneCommandValidator : BaseValidator<ForgetPasswordStepOneCommand>
    {
        public ForgetPasswordStepOneCommandValidator()
        {
            RuleFor(t => t.Email).EmailAddress().WithMessage("Email address is not in a valid format");
        }
    }
}
