using SpeekIO.Application.Interfaces;
using SpeekIO.Infrastructure.Video.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.ApplicationImplementation
{
    internal class JobOperations : IJobOperations
    {
        private readonly IVideoService videoService;

        public JobOperations(IVideoService videoService)
        {
            this.videoService = videoService;
        }
        public void CreateJob(string jobName)
        {
            var session = videoService.CreateNewSession();
            videoService.CreateNewToken(new Domain.Interfaces.Models.VideoSession()
            {
                Id = session.Id,
                Role = session.Role
            });

            throw new NotImplementedException();
        }
    }
}
