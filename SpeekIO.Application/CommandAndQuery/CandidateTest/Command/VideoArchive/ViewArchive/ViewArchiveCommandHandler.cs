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

namespace SpeekIO.Application.Commands.CandidateTest.VideoArchive.ViewArchive
{
	public class ViewArchiveCommandHandler : IRequestHandler<ViewArchiveCommand, ViewArchiveResponse>
	{

		private readonly ILogger<ViewArchiveCommandHandler> _logger;
		private readonly IVideoService _videoService;
		private readonly AutoMapper.IMapper _mapper;
		private ISpeekIODbContext _context;

		public ViewArchiveCommandHandler(ILogger<ViewArchiveCommandHandler> logger, IVideoService videoService, AutoMapper.IMapper mapper, ISpeekIODbContext context)
		{
			this._logger = logger;
			this._videoService = videoService;
			this._mapper = mapper;
			this._context = context;
		}
		public async Task<ViewArchiveResponse> Handle(ViewArchiveCommand request, CancellationToken cancellationToken)
		{
			VideoSession objVideoSession = new VideoSession();
			objVideoSession.ArchiveId = request.ArchiveId;
			objVideoSession.Role = 0;
			var viewArchive = _videoService.GetArchive(objVideoSession);
			updateVideoQuestion(viewArchive);
			return new ViewArchiveResponse()
			{
				Successful = true,
				ArchiveUrl = viewArchive.Url

			};
		}

		private void updateVideoQuestion(Domain.Interfaces.Models.VideoArchive objVideoArchive)
		{

			var videoQuestion = _context.VideoQuestions.Where(x => x.SessionId == objVideoArchive.SessionId).FirstOrDefault();
			videoQuestion.Url = objVideoArchive.Url;
			videoQuestion.ModifiedOn = DateTime.UtcNow;
			_context.VideoQuestions.Update(videoQuestion);
		}
	}
}
