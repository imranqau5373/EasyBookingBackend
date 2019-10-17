using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using SpeekIO.Application.Validators;

namespace SpeekIO.Application.Commands.Umbraco.ContactUs
{
	public class ContactUsCommandValidator : BaseValidator<ContactUsCommand>
	{

		public ContactUsCommandValidator()
		{
			RuleFor(t => t.Email).NotNull().NotEmpty().WithMessage("Email is missing");
			RuleFor(t => t.Message).NotNull().NotEmpty().WithMessage("Message cannot be empty.");
		}
	}
}
