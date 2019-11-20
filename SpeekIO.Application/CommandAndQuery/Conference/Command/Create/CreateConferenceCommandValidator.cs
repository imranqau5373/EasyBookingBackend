using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Conference.Create
{
    class CreateConferenceCommandValidator : BaseValidator<CreateConferenceCommand>
    {
        public CreateConferenceCommandValidator()
        {
            RuleFor(t => t.Title).NotNull().NotEmpty().WithMessage("Title is missing");
            RuleFor(t => t.Description).NotNull().NotEmpty().WithMessage("Description is missing");
            RuleFor(t => t.ResolutionWidth).NotNull().NotEmpty().WithMessage("ResolutionWidth is missing");
            RuleFor(t => t.ResolutionHeight).NotNull().NotEmpty().WithMessage("ResolutionHeight is missing");
            RuleFor(t => t.ScheduledStartTime).GreaterThan(t => DateTime.UtcNow).WithMessage("ScheduledStartTime cannot be less than current time");
            RuleFor(t => t).Must(t => t.ScheduledEndTime > t.ScheduledStartTime).WithMessage("ScheduledEndTime cannt be less than ScheduledStartTime");
            RuleFor(t => t.ParticipantEmails).NotNull().Must(t => t?.Count > 0).WithMessage("Please add atleast 1 participant");
        }
    }
}
