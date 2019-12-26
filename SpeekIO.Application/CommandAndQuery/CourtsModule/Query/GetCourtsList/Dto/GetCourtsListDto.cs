using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsList.Dto
{
    public class GetCourtsListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }

        public bool? IsDeletedCourt { get; set; }
    }
}
