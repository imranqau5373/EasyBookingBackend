
using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto
{
    public class GetCompanyListQuery : PagingQuery, IRequest<GetCompanyListResponse>
    {
    }
}
