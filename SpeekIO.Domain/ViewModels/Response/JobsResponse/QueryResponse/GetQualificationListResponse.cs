using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.JobsResponse
{
    public class GetQualificationListResponse : CommonResponse
    {
        public IList<GetQualification> Qualifications { get; set; }
    }

    public class GetQualification
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
