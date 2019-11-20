using MediatR;
using SpeekIO.Domain.ViewModels.Response.CandidateTest.ArchiveVideo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.CandidateTest.VideoArchive.ViewArchive
{
	public class ViewArchiveCommand : IRequest<ViewArchiveResponse>
	{

		public string ArchiveId { get; set; }
	}
}
