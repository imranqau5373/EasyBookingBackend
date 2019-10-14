using AutoMapper;
using Microsoft.Extensions.Logging;
using OpenTokSDK;
using Polly;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Interfaces.Models;
using SpeekIO.Domain.Models;
using SpeekIO.Infrastructure.Video.Configuration;
using System;
using System.Collections.Generic;

namespace SpeekIO.Infrastructure.Video.Implementation
{
    internal class OpenTokVideoService : IVideoService
    {
        private readonly IVideoConfiguration configuration;
        private readonly IMapper mapper;
        private readonly ILogger<OpenTokVideoService> logger;

        private readonly int apiKey;
        private readonly string apiSecret;

        public OpenTok OpenTok { get; private set; }

        public OpenTokVideoService(IVideoConfiguration configuration, IMapper mapper, ILogger<OpenTokVideoService> logger)
        {
            this.configuration = configuration;
            this.mapper = mapper;
            this.logger = logger;

            apiKey = int.Parse(configuration.ApiKey);
            apiSecret = configuration.ApiSecret;

            Intialize();
        }

        private void Intialize()
        {
            if (apiKey == 0 || apiSecret == null)
            {
                var message = "The OpenTok API Key and API Secret were not set in the application configuration. " +
                    $"Set the values in App.config and try again. (apiKey = {apiKey}, apiSecret = {apiSecret})";

                logger.LogError(message);
                throw new Exception(message);

            }
            this.OpenTok = new OpenTok(apiKey, apiSecret);
        }

        public VideoSession CreateNewSession(CreateNewSessionModel model)
        {
            logger.LogInformation("Creating new session");

            Session session = null;
            Policy.Handle<Exception>().WaitAndRetry(configuration.RetryCount, (turn, duration) =>
            {
                logger.LogError("Failed to create new Session, retrying");
                return TimeSpan.FromSeconds(configuration.Backoff);
            })
            .Execute(() =>
            {
                session = this.OpenTok.CreateSession(mediaMode: MediaMode.ROUTED, 
                    archiveMode: model.AutoArchive ? ArchiveMode.ALWAYS : ArchiveMode.MANUAL);
            });

            logger.LogInformation("Session creation successful");

            return new VideoSession
            {
                Id = session.Id
            };
        }

        public SessionToken CreateNewToken(VideoSession session)
        {
            logger.LogInformation("Creating new token");
            string token = null;

            Policy.Handle<Exception>().WaitAndRetry(configuration.RetryCount, (turn, duration) =>
            {
                logger.LogError("Failed to create new token, retrying");
                return TimeSpan.FromSeconds(configuration.Backoff);
            })
            .Execute(() =>
            {
                token = this.OpenTok.GenerateToken(session.Id, role: mapper.Map<Role>(session.Role));
            });

            logger.LogInformation("Token creation successful");
            return new SessionToken
            {
                Value = token
            };
        }

        public VideoArchive StartArchiving(VideoSession session, string archiveName, bool audio = true, bool video = true)
        {
            logger.LogInformation("Initiating Archive");

            Archive archive = null;
            Policy.Handle<Exception>().WaitAndRetry(configuration.RetryCount, (turn, duration) =>
            {
                logger.LogError("Failed to start archiving, retrying");
                return TimeSpan.FromSeconds(configuration.Backoff);
            })
            .Execute(() =>
            {
                archive = this.OpenTok.StartArchive(
                    session.Id,
                    name: archiveName,
                    hasAudio: audio,
                    hasVideo: video,
                    outputMode: OutputMode.COMPOSED
                );
            });
            logger.LogInformation("Archiving started");

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
