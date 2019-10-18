using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Configuration
{
    /// <summary>
    /// Define all configuration settings here
    /// </summary>
    public interface IApplicationConfiguration
    {
        int RetryCount { get; }
        int Backoff { get; }
        string AuthKey { get; }
        string Issuer { get; }
        int TokenExpiry { get; }
        string Domain { get; }

		string AdminEmail { get; }
	}
}
