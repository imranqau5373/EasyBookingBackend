﻿using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Entities.CandidateTestEntities;
using SpeekIO.Domain.Entities.CommunicationEntities;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Entities.UmbracoEntities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Interfaces
{
    public interface ISpeekIODbContext
    {
        DbSet<Company> Companies { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<ConferenceSession> ConferenceSessions { get; set; }
        DbSet<ConferenceSessionEvent> ConferenceSessionEvents { get; set; }
        DbSet<Connection> Connections { get; set; }
        DbSet<Participant> Participants { get; set; }
        DbSet<RecordSession> RecordSessions { get; set; }
        DbSet<SessionArchive> SessionArchives { get; set; }

		//Umbraco related Entities
		DbSet<SubscribeEmail> SubscribeEmails { get; set; }

		//Candidate Test Entities

		DbSet<VideoQuestion> VideoQuestions { get; set; }


		DbSet<ContactUs> ContactUs { get; set; }

		Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
