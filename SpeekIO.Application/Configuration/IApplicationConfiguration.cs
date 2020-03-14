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

		string EmailVerificationPageUrl { get; }
		string APIUrl { get; }
		string EmailVerificationEndPoint { get; }
		string ClientAppUrl { get; }
		string ProfilePicturePlaceholderUrl { get; }
        string UserAccountsContainerName { get; }
        string DefaultFileExtension { get; }
        string StorageBlobUrl { get; }
        string AzureUrlBinding { get; }
        string BaseProfilePictureUrl { get; }

		string DefaultPassword { get; }
	}
}
