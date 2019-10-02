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

        public VideoArchive StartArchiving(VideoSession session, string archiveName, bool audio = true, bool video = true)
        {
            Archive archive = this.OpenTok.StartArchive(
                session.Id,
                name: archiveName,
                hasAudio: audio,
                hasVideo: video,
                outputMode: OutputMode.COMPOSED
            );

            return mapper.Map<VideoArchive>(archive);
        }

        public VideoArchive StopArchiving(VideoSession session)
        {
            Archive archive = this.OpenTok.StopArchive(session.Id);
            return mapper.Map<VideoArchive>(archive);
        }

        public (List<VideoArchive>, bool) GetArchives(int pageNumber = 1, int pageSize = 10)
        {
            var offset = (pageNumber - 1) * pageSize;
            ArchiveList archives = this.OpenTok.ListArchives(offset, pageSize);

            bool hasNext = archives.TotalCount > (offset + pageSize);

            return (mapper.Map<List<VideoArchive>>(archives), hasNext);
        }
    }
}
