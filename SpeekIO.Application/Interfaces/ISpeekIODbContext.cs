using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities.CommunicationEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Interfaces
{
    public interface ISpeekIODbContext
    {
        DbSet<ConferenceSession> ConferenceSessions { get; set; }
        DbSet<ConferenceSessionEvent> ConferenceSessionEvents { get; set; }
        DbSet<Connection> Connections { get; set; }
        DbSet<Participant> Participants { get; set; }
        DbSet<RecordSession> RecordSessions { get; set; }
        DbSet<SessionArchive> SessionArchives { get; set; }
    }
}
