using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Dashboard.Query.GetCategories.Dto
{
    public class GetCategoriesDto
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
