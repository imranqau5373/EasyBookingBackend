using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.EmailService.Interfaces
{
    internal interface IEmailConfiguration
    {
        string DefaultProvider { get; }
        string MandrillAPIKey { get; }
        string MandrillSenderEmail { get; }

    }
}
