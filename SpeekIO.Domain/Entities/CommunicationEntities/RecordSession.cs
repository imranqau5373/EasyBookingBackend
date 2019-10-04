using SpeekIO.Domain.Interfaces;
using SpeekIO.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CommunicationEntities
{
    public class RecordSession : SessionBaseEntity, IEntity
    {
        public Participant Participant { get; set; }
    }
}
