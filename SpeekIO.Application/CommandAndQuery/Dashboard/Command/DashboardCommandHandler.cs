using MediatR;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Dashboard
{
    public class DashboardCommandHandler : IRequestHandler<DashboardCommand, DashboardResponse>
    {
        public Task<DashboardResponse> Handle(DashboardCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
