using SpeekIO.Domain.Interfaces.Models;
using SpeekIO.Domain.Models;
using System.Collections.Generic;

namespace SpeekIO.Application.Interfaces
{
    public interface IVideoService
    {
        VideoSession CreateNewSession(CreateNewSessionModel model);

        SessionToken CreateNewToken(VideoSession session);

        VideoArchive StartArchiving(VideoSession session, string archiveName, bool audio = true, bool video = true);

        VideoArchive StopArchiving(VideoSession session);

        (List<VideoArchive>, bool) GetArchives(int pageNumber = 1, int pageSize = 10);

    }
}
