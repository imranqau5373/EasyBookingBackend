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

namespace SpeekIO.Application.Commands.CandidateTest.VideoArchive.StopArchive
{
	public class StopArchiveCommandHandler : IRequestHandler<StopArchiveCommand, StopArchiveResponse>
	{

		private readonly ILogger<StopArchiveCommandHandler> _logger;
		private readonly IVideoService _videoService;
		private readonly AutoMapper.IMapper _mapper;

		public StopArchiveCommandHandler(ILogger<StopArchiveCommandHandler> logger, IVideoService videoService, AutoMapper.IMapper mapper)
		{
			this._logger = logger;
			this._videoService = videoService;
			this._mapper = mapper;
		}
		public async Task<StopArchiveResponse> Handle(StopArchiveCommand request, CancellationToken cancellationToken)
		{
			VideoSession objVideoSession = new VideoSession();
			objVideoSession.ArchiveId = request.ArchiveId;
			objVideoSession.Role = 0;
			var stopArchive = _videoService.StopArchiving(objVideoSession);
			return new StopArchiveResponse()
			{
				Successful = true

			};
		}


	}
}
