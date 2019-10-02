using AutoMapper;
using OpenTokSDK;
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
        private readonly IMapper mapper;

        private readonly int apiKey;
        private readonly string apiSecret;

        public OpenTok OpenTok { get; private set; }

        public OpenTokVideoService(IVideoConfiguration configuration, IMapper mapper)
        {
            this.configuration = configuration;
            this.mapper = mapper;

            apiKey = int.Parse(configuration.ApiKey);
            apiSecret = configuration.ApiSecret;

            Intialize();
        }

        private void Intialize()
        {
            if (apiKey == 0 || apiSecret == null)
            {
                throw new Exception(
                    "The OpenTok API Key and API Secret were not set in the application configuration. " +
                    $"Set the values in App.config and try again. (apiKey = {apiKey}, apiSecret = {apiSecret})");

            }
            this.OpenTok = new OpenTok(apiKey, apiSecret);

        }

        public VideoSession CreateNewSession()
        {
            var session = this.OpenTok.CreateSession(mediaMode: MediaMode.ROUTED, archiveMode: ArchiveMode.MANUAL);

            return new VideoSession
            {
                Id = session.Id
            };
        }

        public SessionToken CreateNewToken(VideoSession session)
        {
            string token = this.OpenTok.GenerateToken(session.Id, role: mapper.Map<Role>(session.Role));

            return new SessionToken
            {
                Value = token
            };
        }

        public bool StartArchiving(VideoSession session, string archiveName, bool audio = true, bool video = true)
        {
            throw new NotImplementedException();
        }

        public bool StopArchiving(VideoSession session)
        {
            throw new NotImplementedException();
        }

        public List<VideoArchive> GetArchives()
        {
            throw new NotImplementedException();
        }
    }
}
