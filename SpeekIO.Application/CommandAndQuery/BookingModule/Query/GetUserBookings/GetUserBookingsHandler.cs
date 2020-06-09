using AutoMapper;
using EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetUserBookings.Dto;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.BookingModule.Query.GetUserBookings
{
    public class GetUserBookingsHandler : CommandHandlerBase<GetUserBookingQuery, GetUserBookingResponse>
    {
		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetUserBookingsHandler(
			ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
			SpeekIOContext context, IMapper mapper) : base(userManager, httpContextAccessor)
		{
			_context = context;
			_mapper = mapper;
		}

		public override Task<GetUserBookingResponse> Handle(GetUserBookingQuery request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
