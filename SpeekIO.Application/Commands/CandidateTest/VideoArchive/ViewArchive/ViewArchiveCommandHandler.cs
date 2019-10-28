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

namespace SpeekIO.Application.Commands.CandidateTest.VideoArchive.ViewArchive
{
	public class ViewArchiveCommandHandler : IRequestHandler<ViewArchiveCommand, ViewArchiveResponse>
	{

		private readonly ILogger<ViewArchiveCommandHandler> _logger;
		private readonly IVideoService _videoService;
		private readonly AutoMapper.IMapper _mapper;

		public ViewArchiveCommandHandler(ILogger<ViewArchiveCommandHandler> logger, IVideoService videoService, AutoMapper.IMapper mapper)
		{
			this._logger = logger;
			this._videoService = videoService;
			this._mapper = mapper;
		}
		public async Task<ViewArchiveResponse> Handle(ViewArchiveCommand request, CancellationToken cancellationToken)
		{
			VideoSession objVideoSession = new VideoSession();
			objVideoSession.ArchiveId = request.ArchiveId;
			objVideoSession.Role = 0;
			var viewArchive = _videoService.GetArchive(objVideoSession);
			return new ViewArchiveResponse()
			{
				Successful = true,
				ArchiveUrl = viewArchive.Url

			};
		}
	}
}
