using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.UpdateCourts.Dto
{
    public class UpdateCourtsCommand : IRequest<UpdateCourtsResponse>
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public long? CompanyId { get; set; }

        public long? SportsId { get; set; }
    }

}
