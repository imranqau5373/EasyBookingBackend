using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetBookingCompanies.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetBookingCompanies
{
    public class GetBookingCompaniesQueryHandler : IRequestHandler<GetBookingCompaniesQuery, GetBookingCompaniesResponse>
    {

		private readonly ILogger<GetBookingCompaniesQueryHandler> _logger;
		private readonly AutoMapper.IMapper _mapper;
		private readonly SpeekIOContext _context;

		public GetBookingCompaniesQueryHandler(	ILogger<GetBookingCompaniesQueryHandler> logger,
			AutoMapper.IMapper mapper, SpeekIOContext context)
		{
			this._logger = logger;
			this._mapper = mapper;
			this._context = context;
		}

		public async Task<GetBookingCompaniesResponse> Handle(GetBookingCompaniesQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var companiesList = await _context.Courts.Include(x => x.CourtsDurations).Include(x => x.CourtBookings)
										.Where(x => x.CourtBookings.Count > 0).Select(x => new GetBookingsComapnyDto
										{
											Id = x.Company.Id,
											CompanyName = x.Company.Name
										}).ToListAsync();
				return new GetBookingCompaniesResponse
				{
					BookingCompanyList = companiesList,
					Successful = true
				};
			}
			catch (Exception)
			{
				return new GetBookingCompaniesResponse
				{
					Message = "Error getting in companies list.",
					Successful = false
				};
			}
		}
	}
}
