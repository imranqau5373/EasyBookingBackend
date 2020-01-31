using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration.Dto
{
    public class AddCourtsDurationCommand : IRequest<AddCourtsDurationResponse>
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public long? CourtId { get; set; }
		public long? UserId { get; set; }
		public int SlotDuration { get; set; }
		public DateTime? CourtStartTime { get; set; }
		public DateTime? CourtEndTime { get; set; }

		public DateTime? CourtDate { get; set; }

	}
}
