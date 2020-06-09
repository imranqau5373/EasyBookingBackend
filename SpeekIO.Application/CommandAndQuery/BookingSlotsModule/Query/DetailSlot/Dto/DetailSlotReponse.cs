using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.BookingSlotsModule.Query.DetailSlot.Dto
{
    public class DetailSlotReponse : CommonResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public DateTime? BookingStartTime { get; set; }
        public DateTime? BookingEndTime { get; set; }

        public long? PinCode { get; set; }

        public long? SlotAmount { get; set; }

        public bool SlotIsPaid { get; set; }

        public string BookedEmail { get; set; }

        public long SlotDuration { get; set; }

        public string CompanyName { get; set; }
    }
}
