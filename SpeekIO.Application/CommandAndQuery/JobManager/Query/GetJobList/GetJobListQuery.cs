using MediatR;
using SpeekIO.Application.Common.CommandAndQuery;
using SpeekIO.Domain.ViewModels.Response.JobsResponse.QueryResponse;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Queries.JobManager.GetJobList
{
    public class GetJobListQuery : PagingQuery, IRequest<GetJobListResponse>
    {
        public int StatusId { get; set; }
    }
}
