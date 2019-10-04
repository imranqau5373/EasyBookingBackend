using MediatR;
using SpeekIO.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands
{
    public class CreateJobCommandHandler : IRequestHandler<CreateJobCommand>
    {
        private IMediator _mediator;

        public CreateJobCommandHandler(IMediator mediator, ISpeekIODbContext context)
        {
            this._mediator = mediator;
        }


        public Task<Unit> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            // business logic
            throw new NotImplementedException();
        }
    }
}
