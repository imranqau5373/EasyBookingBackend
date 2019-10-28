using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Application.Queries.Dashboard.Job;
using SpeekIO.Domain.Models;
using SpeekIO.Domain.ViewModels.Response.CandidateTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.CandidateTest.VideoQuestion
{
	public class VideoQuestionQueryHandler : IRequestHandler<VideoQuestionQuery, VideoQeustionResponse>
	{

		private readonly ILogger<JobQueryHandler> _logger;
		private readonly IVideoService _videoService;
		private readonly AutoMapper.IMapper _mapper;
		public VideoQuestionQueryHandler(ILogger<JobQueryHandler> logger, IVideoService videoService, AutoMapper.IMapper mapper)
		{
			this._logger = logger;
			this._videoService = videoService;
			this._mapper = mapper;
		}
		public async Task<VideoQeustionResponse> Handle(VideoQuestionQuery request, CancellationToken cancellationToken)
		{
			//need to get token key and secret.
			CreateNewSessionModel objSessionModel = new CreateNewSessionModel();
			objSessionModel.AutoArchive = false;
			var sessionResponse = _videoService.CreateNewSession(objSessionModel);

			var newToken = _videoService.CreateNewToken(sessionResponse);

			return new VideoQeustionResponse()
			{
				SessionId = sessionResponse.Id.ToString(),
				ApiKey = "46442882",
				Token = newToken.Value.ToString(),
				Successful = true
				
			};

		}
	}
}
