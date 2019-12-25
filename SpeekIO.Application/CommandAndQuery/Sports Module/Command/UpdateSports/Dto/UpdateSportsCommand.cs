using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.Sports_Module.Command.UpdateSports.Dto
{
	public class UpdateSportsCommand : IRequest<UpdateSportsResponse>
	{
		public long Id { get; set; }
		public string Name { get; set; }

		public string Description { get; set; }

		public long? CompanyId { get; set; }
	}
}
