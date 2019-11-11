using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.JobsResponse.QueryResponse
{
    public class GetJobListResponse : CommonResponse
    {
        public List<GetJobListModel> Jobs { get; set; }
    }

    public class GetJobListModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Reference { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string RelativeTime { get; set; }
    }
}
