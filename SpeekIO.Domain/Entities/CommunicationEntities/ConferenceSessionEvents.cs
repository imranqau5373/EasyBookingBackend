using SpeekIO.Domain.Enums.EntityEnums;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class ConferenceSessionEvents : BaseEntity, IEntity
    {
        public ConferenceSession ConferenceSession { get; set; }

        // Sender
        // Recipient

        public ConferenceSessionEventType EventType { get; set; }

        public string Message { get; set; }
    }
}
