using MediatR;
using SpeekIO.Domain.ViewModels.Response.CandidateTest.ArchiveVideo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.CandidateTest.VideoArchive.StopArchive
{
	public class StopArchiveCommand : IRequest<StopArchiveResponse>
	{

		public string ArchiveId { get; set; }
	}
}
