using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.Email
{
    public class EmailRecipientPayloadInfo : IEmailRecipientPayloadInfo
    {
        public EmailRecipientPayloadInfo(IRecipient recipient, Dictionary<string, object> payload)
        {
            this.Recipient = recipient;
            this.Payload = payload;
        }
        public IRecipient Recipient { get; private set; }

        public Dictionary<string, object> Payload { get; private set; }
    }
}
