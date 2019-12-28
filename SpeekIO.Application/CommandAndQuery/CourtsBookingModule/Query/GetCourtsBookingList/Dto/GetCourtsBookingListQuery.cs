
using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBookingList.Dto
{
    public class GetCourtsBookingListQuery : PagingQuery, IRequest<GetCourtsBookingListResponse>
    {
    }
}
