
using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDurationList.Dto
{
    public class GetCourtsDurationListQuery : PagingQuery, IRequest<GetCourtsDurationListResponse>
    {
    }
}
