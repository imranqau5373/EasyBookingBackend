using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompany.Dto
{
    public class GetCompanyQuery : IRequest<GetCompanyResponse>
    {
        public long Id { get; set; }
    }
}
