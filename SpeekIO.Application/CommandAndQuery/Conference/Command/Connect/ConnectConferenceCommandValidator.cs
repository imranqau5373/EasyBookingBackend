using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Conference.Connect
{
    public class ConnectConferenceCommandValidator : BaseValidator<ConnectConferenceCommand>
    {
        public ConnectConferenceCommandValidator()
        {
            RuleFor(t => t.ConferenceId).Must(t => t > 0).WithMessage("Conference Id is missing");
        }
    }
}
