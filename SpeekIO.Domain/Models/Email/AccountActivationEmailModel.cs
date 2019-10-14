using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.Models.Email
{
    public class AccountActivationEmailModel : IEmailModel
    {
        private readonly string _activationUrl;
        private readonly IRecipient _recipient;

        public AccountActivationEmailModel(string activationUrl, IRecipient recipient)
        {
            this._activationUrl = activationUrl;
            this._recipient = recipient;
        }

        public string TemplateName => "AccountActivation";

        public IList<IEmailRecipientPayloadInfo> Prepare()
        {
            IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

            var payload = new Dictionary<string, object>();
            payload.Add("Name", _recipient.FullName);
            payload.Add("ActivationUrl", _activationUrl);

            list.Add(new EmailRecipientPayloadInfo(_recipient, Subject(), payload));

            return list;
        }

        private string Subject()
        {
            return "Activate your SpeekIO Account";
        }
    }
}
