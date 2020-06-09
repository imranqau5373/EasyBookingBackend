using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Models.Email.Booking
{
    public class BookingInviteEmailModel: IEmailModel
    {

        private readonly string _activationUrl;
        private readonly IRecipient _recipient;

        public BookingInviteEmailModel(string activationUrl, IRecipient recipient)
        {
            this._activationUrl = activationUrl;
            this._recipient = recipient;
        }

        public string TemplateName { get; set; } = "BookingInvite";

        public IList<IEmailRecipientPayloadInfo> Prepare()
        {
            IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

            var payload = new Dictionary<string, object>();
            payload.Add("ActivationUrl", _activationUrl);

            list.Add(new EmailRecipientPayloadInfo(_recipient, Subject(), payload));

            return list;
        }

        private string Subject()
        {
            return "Booking Invitation Email";
        }
    }
}
