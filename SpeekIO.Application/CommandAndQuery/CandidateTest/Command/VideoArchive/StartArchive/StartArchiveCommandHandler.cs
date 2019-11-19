
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
		private ISpeekIODbContext _context;

		public StartArchiveCommandHandler(ILogger<StartArchiveCommandHandler> logger, IVideoService videoService, AutoMapper.IMapper mapper, ISpeekIODbContext context)
		{
			this._logger = logger;
			this._videoService = videoService;
			this._mapper = mapper;
			this._context = context;
		}
		public async Task<StartArchiveResponse> Handle(StartArchiveCommand request, CancellationToken cancellationToken)
		{
			VideoSession objVideoSession = new VideoSession();
			objVideoSession.Id = request.SessionId;
			objVideoSession.Role = 0;
			var startArchive = _videoService.StartArchiving(objVideoSession, "First Archive");
			saveVideoQuestion(startArchive);
			return new StartArchiveResponse()
			{
				ArchiveId = startArchive.Id.ToString(),
				Successful = true

			};
		}

		private async void saveVideoQuestion(Domain.Interfaces.Models.VideoArchive objVideoArchive)
		{
			
			var videoQuestion =  _mapper.Map<Domain.Entities.CandidateTestEntities.VideoQuestion>(objVideoArchive);
			videoQuestion.ArchiveId = objVideoArchive.Id;
			videoQuestion.VideoStartTime = DateTime.UtcNow;
			await _context.VideoQuestions.AddAsync(videoQuestion);
		}


	}
}
