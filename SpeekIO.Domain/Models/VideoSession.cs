using SpeekIO.Domain.Enums.Video;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Interfaces.Models
{
    public class VideoSession
    {
        public string Id { get; set; }
        public VideoRole Role { get; set; }

		public string ArchiveId { get; set; }
    }
}
