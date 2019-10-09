using SpeekIO.Domain.Enums.EntityEnums;
using SpeekIO.Domain.Enums.Video;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response
{
    public class ConnectConferenceResponse : CommonResponse
    {
        public ConnectConferenceResponse()
        {
        }

        public ConnectConferenceResponse(bool success, string message)
        {
            Successful = success;
            Message = message;
        }

        public string Token { get; set; }
        public VideoRole Role { get; set; }
        public bool AllowRecording { get; set; }
        public bool AutoConnect { get; set; }
        public bool AutoRecording { get; set; }
        public ConferenceSessionState State { get; set; }

    }
}
