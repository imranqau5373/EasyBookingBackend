using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Enums.Video
{
    public enum VideoRole
    {
        PUBLISHER = 0,
        SUBSCRIBER = 1,
        MODERATOR = 2
    }

    public enum VideoArchiveStatus
    {
        AVAILABLE = 0,
        DELETED = 1,
        FAILED = 2,
        PAUSED = 3,
        STARTED = 4,
        STOPPED = 5,
        UPLOADED = 6,
        EXPIRED = 7,
        UNKOWN = 8
    }
    //
    public enum VideoOutputMode
    {
        COMPOSED = 0,
        INDIVIDUAL = 1
    }
}
