using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Commands.Dashboard
{
    public class DashboardCommand : IRequest<DashboardResponse>
    {
        public string DashboardMessag { get; set; }
    }
}
