using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class SessionLogs : BaseEntity, IEntity
    {
        public string SessionId { get; set; }
        public string ProjectId { get; set; }
        public string EventName { get; set; }
        public string Reason { get; set; }
        public long Timestamp { get; set; }
        public string Payload { get; set; }
    }
}
