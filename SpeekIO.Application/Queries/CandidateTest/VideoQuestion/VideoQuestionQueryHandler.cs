using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Application.Queries.Dashboard.Job;
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

		public VideoQuestionQueryHandler(ILogger<JobQueryHandler> logger)
		{
			this._logger = logger;
		}
		public Task<VideoQeustionResponse> Handle(VideoQuestionQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
