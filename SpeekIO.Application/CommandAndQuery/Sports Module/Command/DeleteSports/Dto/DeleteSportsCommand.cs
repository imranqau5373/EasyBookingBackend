using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteSports.Dto
{
    public class DeleteSportsCommand : IRequest<DeleteSportsResponse>
    {
        public long Id { get; set; }
    }
}
