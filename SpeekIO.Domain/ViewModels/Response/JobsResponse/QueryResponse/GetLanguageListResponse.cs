using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Domain.ViewModels.Response.JobsResponse
{
    public class GetLanguageListResponse : CommonResponse
    {
        public IList<GetLanguageModel> Languages { get; set; }
    }

    public class GetLanguageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
