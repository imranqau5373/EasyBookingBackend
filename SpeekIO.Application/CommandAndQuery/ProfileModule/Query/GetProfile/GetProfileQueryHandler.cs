using AutoMapper;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Query.GetProfile.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Query.GetProfile
{
	public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, GetProfileResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetProfileQueryHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<GetProfileResponse> Handle(GetProfileQuery request, CancellationToken cancellationToken)
		{
			try
			{
				var profileObject = await _context.Profiles.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
				if (profileObject == null)
				{
					return new GetProfileResponse()
					{
						Successful = false,
						Message = "Profile is not found."
					};
				}
				else
				{
					var response = _mapper.Map<GetProfileResponse>(profileObject);
					response.Successful = true;
					response.Message = "Profile found successfully.";
					return response;
				}

			}
			catch (Exception ex)
			{
				return new GetProfileResponse()
				{
					Successful = false,
					Message = "Something went wrong while getting Profile. " + ex.Message
				};
			}
		}
	}
}
