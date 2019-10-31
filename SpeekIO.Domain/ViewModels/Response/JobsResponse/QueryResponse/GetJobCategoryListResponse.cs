using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.JobsResponse
{
    public class GetJobCategoryListResponse : CommonResponse
    {
        public IList<GetJobCategory> JobCategories { get; set; }
    }

    public class GetJobCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
