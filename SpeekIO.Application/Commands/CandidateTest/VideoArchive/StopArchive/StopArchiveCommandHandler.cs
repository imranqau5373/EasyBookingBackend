using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Interfaces.Models;
using SpeekIO.Domain.ViewModels.Response.CandidateTest.ArchiveVideo;
using System;
using System.Collections.Generic;
using System.Linq;
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
		private ISpeekIODbContext _context;

		public StopArchiveCommandHandler(ILogger<StopArchiveCommandHandler> logger, IVideoService videoService, AutoMapper.IMapper mapper, ISpeekIODbContext context)
		{
			this._logger = logger;
			this._videoService = videoService;
			this._mapper = mapper;
			this._context = context;
		}
		public async Task<StopArchiveResponse> Handle(StopArchiveCommand request, CancellationToken cancellationToken)
		{
			VideoSession objVideoSession = new VideoSession();
			objVideoSession.ArchiveId = request.ArchiveId;
			objVideoSession.Role = 0;
			var stopArchive = _videoService.StopArchiving(objVideoSession);
			updateVideoQuestion(stopArchive);
			return new StopArchiveResponse()
			{
				Successful = true

			};
		}

		private void updateVideoQuestion(Domain.Interfaces.Models.VideoArchive objVideoArchive)
		{

			var videoQuestion = _context.VideoQuestions.Where(x => x.SessionId == objVideoArchive.SessionId).FirstOrDefault();
			videoQuestion.ArchiveId = objVideoArchive.Id;
			videoQuestion.ModifiedOn = videoQuestion.VideoEndTime = DateTime.UtcNow;
			_context.VideoQuestions.Update(videoQuestion);
		}


	}
}
