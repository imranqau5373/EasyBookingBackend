using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SpeekIO.Application.Commands.Conference.ConnectionLog
{
    public class ConnectionLogCommandValidator : BaseValidator<ConnectionLogCommand>
    {
        public ConnectionLogCommandValidator()
        {
            RuleFor(t => t.ConferenceId).GreaterThan(0).WithMessage("ConferenceId is missing");
            RuleFor(t => t.ConnectionId).NotNull().NotEmpty().WithMessage("ConnectionId is missing");
            RuleFor(t => t.IpAddress).Must(t => IPAddress.TryParse(t, out IPAddress address)).WithMessage("IPAddress is not in a valid format");
        }
    }
}
