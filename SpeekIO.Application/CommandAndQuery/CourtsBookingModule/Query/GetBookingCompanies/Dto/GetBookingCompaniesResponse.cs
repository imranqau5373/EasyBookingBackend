using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetBookingCompanies.Dto
{
    public class GetBookingCompaniesResponse : CommonResponse
    {
        public List<GetBookingsComapnyDto> BookingCompanyList { get; set; }

    }
}
