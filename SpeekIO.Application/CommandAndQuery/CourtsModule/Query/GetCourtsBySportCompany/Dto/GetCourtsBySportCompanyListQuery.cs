using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsBySportCompany.Dto
{
    public class GetCourtsBySportCompanyListQuery : PagingQuery, IRequest<GetCourtsBySportCompanyListResponse>
    {
        public long CompanyId { get; set; }
        public long SportId { get; set; }
    }
}
