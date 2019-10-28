using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Interfaces.Models;
using SpeekIO.Domain.ViewModels.Response.CandidateTest.ArchiveVideo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.CandidateTest.VideoArchive.StartArchive
{
	public class StartArchiveCommandHandler : IRequestHandler<StartArchiveCommand, StartArchiveResponse>
	{
		private readonly ILogger<StartArchiveCommandHandler> _logger;
		private readonly IVideoService _videoService;
		private readonly AutoMapper.IMapper _mapper;

		public StartArchiveCommandHandler(ILogger<StartArchiveCommandHandler> logger, IVideoService videoService, AutoMapper.IMapper mapper)
		{
			this._logger = logger;
			this._videoService = videoService;
			this._mapper = mapper;
		}
		public async Task<StartArchiveResponse> Handle(StartArchiveCommand request, CancellationToken cancellationToken)
		{
			VideoSession objVideoSession = new VideoSession();
			objVideoSession.Id = request.SessionId;
			objVideoSession.Role = 0;
			var startArchive = _videoService.StartArchiving(objVideoSession, "First Archive");
			return new StartArchiveResponse()
			{
				ArchiveId = startArchive.Id.ToString(),
				Successful = true

			};
		}


	}
}
