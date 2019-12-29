using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany.Dto
{
    public class AddCompanyResponse : CommonResponse
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string SubDomainPrefix { get; set; }
    }
}
