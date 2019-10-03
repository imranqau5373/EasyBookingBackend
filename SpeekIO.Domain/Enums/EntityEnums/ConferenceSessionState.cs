using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Enums.EntityEnums
{
    public enum ConferenceSessionState
    {
        NoSession = 0,
        Scheduled = 1,
        ScheduleRequest = 2,
        ScheduleRequestRejected = 3,
        CallRequest = 5,
        Active = 8,
        Ended = 13,
        ChatActive = 21,
        VideoMessageRequest = 34,
        Hidden = 55
    }
}
