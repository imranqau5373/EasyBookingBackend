using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.AddCourts.Dto
{
    public class AddCourtsResponse : CommonResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public long? CompanyId { get; set; }

        public long? SportsId { get; set; }
    }
}
