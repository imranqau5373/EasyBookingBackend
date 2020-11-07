using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Dashboard.Query.GetCategories.Dto
{
    public class GetCategoriesQuery : PagingQuery, IRequest<GetCategoriesResponse>
    {
        public long CompanyId { get; set; }
        
    }
}
