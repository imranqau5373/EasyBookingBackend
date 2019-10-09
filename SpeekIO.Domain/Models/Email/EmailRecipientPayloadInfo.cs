using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.Email
{
    public class EmailRecipientPayloadInfo : IEmailRecipientPayloadInfo
    {
        public EmailRecipientPayloadInfo(IRecipient recipient, string subject, Dictionary<string, object> payload)
        {
            Recipient = recipient;
            Payload = payload;
            Subject = subject;
        }
        public IRecipient Recipient { get; private set; }

        public Dictionary<string, object> Payload { get; private set; }

        public string Subject { get; private set; }
    }
}
