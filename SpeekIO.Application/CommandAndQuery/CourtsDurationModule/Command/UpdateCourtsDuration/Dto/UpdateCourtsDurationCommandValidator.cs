using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.UpdateCourtsDuration.Dto
{
    public class UpdateCourtsDurationCommandValidator : BaseValidator<UpdateCourtsDurationCommand>
    {
        public UpdateCourtsDurationCommandValidator()
        {
            RuleFor(t => t.Name).NotEmpty().WithMessage(" name is missing.");
        }
    }
}
