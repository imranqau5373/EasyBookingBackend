using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Models.Email.Booking
{
    public class BookingCancelEmailModel : IEmailModel
    {
        private readonly string _cancelMessge;
        private readonly IRecipient _recipient;

        public BookingCancelEmailModel(string cancelMessage, IRecipient recipient)
        {
            this._cancelMessge = cancelMessage;
            this._recipient = recipient;
        }

        public string TemplateName { get; set; } = "BookingCancel";

        public IList<IEmailRecipientPayloadInfo> Prepare()
        {
            IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

            var payload = new Dictionary<string, object>();
            payload.Add("Message", _cancelMessge);

            list.Add(new EmailRecipientPayloadInfo(_recipient, Subject(), payload));

            return list;
        }

        private string Subject()
        {
            return "Activate your SpeekIO Account";
        }

    }
}
