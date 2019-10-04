using SpeekIO.Domain.Enums.EntityEnums;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class ConferenceSession : SessionBaseEntity, IEntity
    {
        // When conference is scheduled, then it has start time and duration of session
        public DateTime ScheduledStartTime { get; set; }
        public DateTime ScheduledEndTime { get; set; }

        // To specify if this is a broadcast session
        // mute all clients. Only Host is allowed to unmute and mute them
        public bool IsBroadcast { get; set; }

        // Enable recording by default, disable automatic recording by setting it to false
        public bool RecordAutomatically { get; set; }

        // Allow users to connect to session who dont have link to the session
        // this property is useful when broadcasting to allow join the session from anywhere
        public bool IsPublic { get; set; }
        public bool AutoAcceptConference { get; set; }
        public bool AllowRecordingOfHost { get; set; }
        public bool AllowRecordingOfParticipants { get; set; }

        public ConferenceSessionState State { get; set; }

        public List<ConferenceSessionEvent> ConferenceSessionEvents { get; set; }

    }
}
