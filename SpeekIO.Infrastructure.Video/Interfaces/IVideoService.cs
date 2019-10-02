using SpeekIO.Domain.Interfaces.Models;
using System.Collections.Generic;

namespace SpeekIO.Infrastructure.Video.Interfaces
{
    public interface IVideoService
    {
        Session CreateNewSession();

        Token CreateNewToken(Session session);

        bool StartArchiving(Session session, string archiveName, bool audio = true, bool video = true);

        bool StopArchiving(Session session);

        List<Archive> GetArchives();

    }
}
