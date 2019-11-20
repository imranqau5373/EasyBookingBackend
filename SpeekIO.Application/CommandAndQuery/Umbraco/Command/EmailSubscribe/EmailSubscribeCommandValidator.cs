using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Umbraco
{
	public class EmailSubscribeCommandValidator : BaseValidator<EmailSubscribeCommand>
	{
		public EmailSubscribeCommandValidator()
		{
			RuleFor(t => t.EmailAddress).NotNull().NotEmpty().WithMessage("Email is missing");
			RuleFor(t => t.isSubscribed).NotNull().NotEmpty().WithMessage("Subscription value is missing");
		}
	}
}
