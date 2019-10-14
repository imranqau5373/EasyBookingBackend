using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Conference.Connect
{
    public class ConnectConferenceCommand : IRequest<ConnectConferenceResponse>
    {
        public long ConferenceId { get; set; }
    }
}
