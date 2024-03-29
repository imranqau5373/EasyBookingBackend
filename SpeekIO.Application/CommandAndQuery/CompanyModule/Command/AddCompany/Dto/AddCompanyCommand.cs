﻿using MediatR;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany.Dto
{
    public class AddCompanyCommand : IRequest<AddCompanyResponse>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string SubDomainPrefix { get; set; }
        public long? PackageId { get; set; }
    }
}
