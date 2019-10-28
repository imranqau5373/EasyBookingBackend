using MediatR;
using SpeekIO.Domain.ViewModels.Response.GetJobResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Queries.Job
{
    public class GetJobQuery : IRequest<GetJobResponse>
    {
        public int Id { get; set; }
    }
}
