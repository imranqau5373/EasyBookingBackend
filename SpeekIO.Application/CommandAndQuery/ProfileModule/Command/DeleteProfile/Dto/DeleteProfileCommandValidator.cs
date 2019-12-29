using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.DeleteProfile.Dto
{
    public class DeleteProfileCommandValidator : BaseValidator<DeleteProfileCommand>
    {
        public DeleteProfileCommandValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Please provide valid Identifier.");
        }
    }
}
