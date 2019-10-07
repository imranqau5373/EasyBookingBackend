using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Interfaces.Email
{
    public interface IEmailRecipientPayloadInfo
    {
        IRecipient Recipient { get; }
        Dictionary<string, object> Payload { get; }
    }
}
