using SpeekIO.Domain.Intefaces.Email;
using SpeekIO.Domain.Interfaces.Email;
using SpeekIO.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Domain.Models.Email.Booking
{
    public class BookingConfirmationEmailModel : IEmailModel
    {

        private readonly BookingDetailEmail _bookingDetails;
        private readonly IRecipient _recipient;

        public BookingConfirmationEmailModel(BookingDetailEmail bookingDetails, IRecipient recipient)
        {
            this._bookingDetails = bookingDetails;
            this._recipient = recipient;
        }

        public string TemplateName { get; set; } = "BookingCancel";

        public IList<IEmailRecipientPayloadInfo> Prepare()
        {
            IList<IEmailRecipientPayloadInfo> list = new List<IEmailRecipientPayloadInfo>();

            var payload = new Dictionary<string, object>();
            payload.Add("PinCode", _bookingDetails.PinCode);
            payload.Add("Name", _bookingDetails.Name);
            payload.Add("StartTime", _bookingDetails.BookingStartTime);
            payload.Add("EndTime", _bookingDetails.BookingEndTime);
            payload.Add("CompanyName", _bookingDetails);


            

            list.Add(new EmailRecipientPayloadInfo(_recipient, Subject(), payload));

            return list;
        }

        private string Subject()
        {
            return "Booking Confirmation Email";
        }
    }

    public class BookingDetailEmail
    {
        public string Name { get; set; }

        public DateTime? BookingStartTime { get; set; }
        public DateTime? BookingEndTime { get; set; }

        public long? PinCode { get; set; }

        public long? SlotAmount { get; set; }

        public bool SlotIsPaid { get; set; }

        public string BookedEmail { get; set; }

        public string CompanyName { get; set; }
    }
}
