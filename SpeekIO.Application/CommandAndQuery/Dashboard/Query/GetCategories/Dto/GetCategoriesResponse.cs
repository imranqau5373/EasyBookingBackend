using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Dashboard.Query.GetCategories.Dto
{
    public class GetCategoriesResponse : CommonResponse
    {
        public List<GetCategoriesDto> Items { get; set; }
        public int TotalCount { get; set; }
    }
}
