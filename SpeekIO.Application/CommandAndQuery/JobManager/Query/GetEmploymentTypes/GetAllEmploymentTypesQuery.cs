using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SpeekIO.Domain.ViewModels.Response.JobsResponse;

namespace SpeekIO.Application.Queries.Job.GetEmploymentTypes
{
    public class GetAllEmploymentTypesQuery : IRequest<GetAllEmploymentTypeListViewModel>
    {

    }
}
