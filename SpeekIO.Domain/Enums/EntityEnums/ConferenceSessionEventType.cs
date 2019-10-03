using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Enums.EntityEnums
{
    public enum ConferenceSessionEventType
    {
        Unknown = 0,
        CallRequest = 1,
        CallRequestRejected = 2,
        CallRequestCanceled = 3,
        SessionJoined = 5,
        SessionLeft = 8,
        Message = 13,
        SessionStarted = 21,
        SessionEnded = 34,
        UpdatedProfile = 55,
        ChatSessionStarted = 89,
        ScheduledCallRequest = 145
    }
}
