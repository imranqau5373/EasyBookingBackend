using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.JobsResponse
{
    public class GetAllEmploymentTypeListViewModel : CommonResponse
    {
        public IList<GetAllEmploymentTypesResponse> EmploymentTypes { get; set; }
    }
}
