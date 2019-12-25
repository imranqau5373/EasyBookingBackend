using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.UpdateSports.Dto
{
	public class UpdateSportsCommandValidator : BaseValidator<UpdateSportsCommand>
	{

		public UpdateSportsCommandValidator()
		{
			RuleFor(t => t.Name).NotEmpty().WithMessage("Sports name is missing.");
		}
	}
}
