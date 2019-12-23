using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto
{
	public class AddSportsCommandValidator : BaseValidator<AddSportsCommand>
	{

		public AddSportsCommandValidator()
		{
			RuleFor(t => t.Name).NotEmpty().WithMessage("Sports name is missing.");
		}
	}
}
