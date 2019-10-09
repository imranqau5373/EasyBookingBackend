using MediatR;
using SpeekIO.Domain.Enums.EntityEnums;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Conference.ConnectionLog
{
    public class ConnectionLogCommand : IRequest<CommonResponse>
    {
        public long ConferenceId { get; set; }
        public ConnectionState State { get; set; }
        public string ConnectionId { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string ReferrerUrl { get; set; }
        public string Url { get; set; }
        public bool IsWebRtcSupported { get; set; }
    }
}
