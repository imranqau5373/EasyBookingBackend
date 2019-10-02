using SpeekIO.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace SpeekIO.Infrastructure.Video.Interfaces
{
    public interface IVideoService
    {
        VideoSession CreateNewSession();

        SessionToken CreateNewToken(VideoSession session);

        bool StartArchiving(VideoSession session, string archiveName, bool audio = true, bool video = true);

        bool StopArchiving(VideoSession session);

        List<VideoArchive> GetArchives();

    }
}
