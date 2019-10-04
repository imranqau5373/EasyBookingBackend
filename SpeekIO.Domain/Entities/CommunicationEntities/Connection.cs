using SpeekIO.Domain.Enums.EntityEnums;
using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class Connection : BaseEntity, IEntity
    {
        public Participant Participant { get; set; }

        public ConnectionState State { get; set; }
        public string ConnectionId { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public string ReferrerUrl { get; set; }
        public string Url { get; set; }
        public bool IsWebRtcSupported { get; set; }
    }
}
