using SpeekIO.Domain.Enums.EntityEnums;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class Participant : BaseEntity, IEntity
    {
        public ParticipantState State { get; set; }

        // TODO: Think about connection

        public DateTime? RequestedToJoinOn { get; set; }
        public DateTime? JoinedOn { get; set; }
        public DateTime? LeftOn { get; set; }
        public ParticipantType ParticipantType { get; set; }
        public string ResolutionWidth { get; set; }
        public string ResolutionHeight { get; set; }
    }
}
