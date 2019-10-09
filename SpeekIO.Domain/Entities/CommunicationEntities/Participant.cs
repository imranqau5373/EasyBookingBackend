using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Enums.EntityEnums;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class Participant : BaseEntity, IEntity
    {
        public ParticipantType ParticipantType { get; set; }
        public ParticipantState State { get; set; }
        public virtual Profile Profile { get; set; }
        public long? ProfileId { get; set; }

        public ConferenceSession ConferenceSession { get; set; }
        public long ConferenceSessionId { get; set; }

        // If a participant connects and then disconnects, then reconnects again then
        // participant will have a new connection. To maintain all connections we need
        // to create a one to many relationship
        public List<Connection> Connections { get; set; }

        public DateTime? RequestedToJoinOn { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? LeftOn { get; set; }
        public string ResolutionWidth { get; set; }
        public string ResolutionHeight { get; set; }
    }
}
