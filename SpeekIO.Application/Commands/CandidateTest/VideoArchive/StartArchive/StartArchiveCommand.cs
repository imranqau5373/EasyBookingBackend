using MediatR;
using SpeekIO.Domain.ViewModels.Response.CandidateTest.ArchiveVideo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.CandidateTest.VideoArchive.StartArchive
{
	public class StartArchiveCommand : IRequest<StartArchiveResponse>
	{
		public string SessionId { get; set; }
	}
}
