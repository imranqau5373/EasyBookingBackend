using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourts.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourts
{
    public class GetCourtsQueryHandler : IRequestHandler<GetCourtsQuery, GetCourtsResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetCourtsQueryHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetCourtsResponse> Handle(GetCourtsQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var courtsObject = await _context.Courts.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				if (courtsObject == null)
				{
					return new GetCourtsResponse()
					{
						Successful = false,
						Message = "Court is not found."
					};
				}
				else
				{
					var response = _mapper.Map<GetCourtsResponse>(courtsObject);
					response.Successful = true;
					response.Message = "Court found successfully.";
					return response;
				}

			}
			catch (Exception ex)
			{
				return new GetCourtsResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting court. " + ex.Message
				};
			}
		}
	}
}
