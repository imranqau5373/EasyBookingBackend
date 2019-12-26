using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsList.Dto
{
    public class GetCourtsListQuery : PagingQuery, IRequest<GetCourtsListResponse>
    {
    }
}
