using SpeekIO.Domain.Enums.Video;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Interfaces.Models
{
    public class VideoArchive
    {
        public VideoArchiveStatus Status { get; set; }
        public long Size { get; set; }
        public VideoOutputMode OutputMode { get; set; }
        public string Resolution { get; set; }
        public bool HasAudio { get; set; }
        public bool HasVideo { get; set; }
        public string Reason { get; set; }
        public string SessionId { get; set; }
        public int PartnerId { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
        public long Duration { get; set; }
        public long CreatedAt { get; set; }
        public string Url { get; set; }
        public string Password { get; set; }
    }
}
