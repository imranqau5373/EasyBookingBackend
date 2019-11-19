using MediatR;
using SpeekIO.Domain.ViewModels.Response.CandidateTest;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.CandidateTest.VideoQuestion
{
	public class VideoQuestionCommandHandler : IRequestHandler<VideoQuestionCommand, VideoQeustionResponse>
	{
		public Task<VideoQeustionResponse> Handle(VideoQuestionCommand request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
