using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Video.Configuration
{
    public interface IVideoConfiguration
    {
        string ApiKey { get; }
        string ApiSecret { get; }

        int RetryCount { get; }
        int Backoff { get; }
    }
}
