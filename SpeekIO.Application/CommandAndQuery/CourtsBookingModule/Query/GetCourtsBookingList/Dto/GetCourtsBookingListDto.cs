using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto
{
    public class GetCourtsBookingListDto
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CourtName { get; set; }
        public string UserName { get; set; }
        public long? CourtId { get; set; }
        public long? UserId { get; set; }

        public long? PinCode { get; set; }

        public DateTime? BookingStartTime { get; set; }
        public DateTime? BookingEndTime { get; set; }
        public bool IsBooked { get; set; }
        public bool IsEmailed { get; set; }

        public long? CompanyId { get; set; }
    }
}
