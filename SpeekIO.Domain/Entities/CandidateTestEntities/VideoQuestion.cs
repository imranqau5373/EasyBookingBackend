using SpeekIO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Entities.CandidateTestEntities
{
	public class VideoQuestion : BaseEntity, IEntity
	{

		public long Size { get; set; }
		public string Resolution { get; set; }
		public bool HasAudio { get; set; }
		public bool HasVideo { get; set; }
		public string Reason { get; set; }
		public string SessionId { get; set; }
		public int PartnerId { get; set; }
		public string Name { get; set; }
		public Guid ArchiveId { get; set; }
		public long Duration { get; set; }
		public long CreatedAt { get; set; }
		public string Url { get; set; }
		public string Password { get; set; }

		public DateTime VideoStartTime { get; set; }

		public DateTime VideoEndTime { get; set; }

		public int UserId { get; set; }




	}
}
