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
        private IJobOperations _jobOperations;
        private IMediator _mediator;

        public CreateJobCommandHandler(IJobOperations jobOperations, IMediator mediator)
        {
            this._jobOperations = jobOperations;
            this._mediator = mediator;
        }


        public Task<Unit> Handle(CreateJobCommand request, CancellationToken cancellationToken)
        {
            _jobOperations.CreateJob(request.JobName);
            // business logic
            throw new NotImplementedException();
        }
    }
}
