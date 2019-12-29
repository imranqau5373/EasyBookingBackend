using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.UpdateCourtsDuration.Dto
{
    public class UpdateCourtsDurationCommand : IRequest<UpdateCourtsDurationResponse>
    {
        public long? Id { get; set; }
		public string Name { get; set; }

		public string Description { get; set; }

		public long? CourtId { get; set; }

		public long? CompanyId { get; set; }

		public DateTime? CourtStartTime { get; set; }

		public DateTime? CourtEndTime { get; set; }

		public DateTime? CourtDuration { get; set; }
	}
}
