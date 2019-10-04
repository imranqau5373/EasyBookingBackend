using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public abstract class SessionBaseEntity : BaseEntity, IEntity
    {
        public string SessionIdentifier { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool EnableAudio { get; set; }
        public bool EnableVideo { get; set; }

        public string ResolutionWidth { get; set; }
        public string ResolutionHeight { get; set; }

        public List<SessionArchive> Archives { get; set; }

    }
}
