using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteCompany.Dto
{
    public class DeleteCompanyCommand : IRequest<DeleteCompanyResponse>
    {
        public long Id { get; set; }
    }
}
