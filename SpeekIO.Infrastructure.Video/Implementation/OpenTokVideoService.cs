using SpeekIO.Domain.Interfaces.Models;
using SpeekIO.Infrastructure.Video.Configuration;
using SpeekIO.Infrastructure.Video.Interfaces;
using System;
using System.Collections.Generic;

namespace SpeekIO.Infrastructure.Video.Implementation
{
    internal class OpenTokVideoService : IVideoService
    {
        private readonly IVideoConfiguration configuration;

        public OpenTokVideoService(IVideoConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Session CreateNewSession()
        {
            throw new NotImplementedException();
        }

        public Token CreateNewToken(Session session)
        {
            throw new NotImplementedException();
        }

        public List<Archive> GetArchives()
        {
            throw new NotImplementedException();
        }

        public bool StartArchiving(Session session, string archiveName, bool audio = true, bool video = true)
        {
            throw new NotImplementedException();
        }

        public bool StopArchiving(Session session)
        {
            throw new NotImplementedException();
        }
    }
}
