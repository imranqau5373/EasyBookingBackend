using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class SessionArchive : BaseEntity, IEntity
    {
        public long CreatedAt { get; set; }
        public long Duration { get; set; }
        public Guid ArchiveId { get; set; }
        public string Name { get; set; }
        public int PartnerId { get; set; }
        public string Reason { get; set; }
        public string SessionId { get; set; }
        public long Size { get; set; }
        public int Status { get; set; }
        public string Url { get; set; }
        public virtual string Password { get; set; }
    }
}
