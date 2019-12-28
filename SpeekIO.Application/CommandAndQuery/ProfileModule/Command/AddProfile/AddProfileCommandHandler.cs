using AutoMapper;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.AddProfile.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.AddProfile
{
	public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand, AddProfileResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddProfileCommandHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<AddProfileResponse> Handle(AddProfileCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var profileModel = _mapper.Map<SpeekIO.Domain.Entities.Portfolio.Profile>(request);
				var profileData = await _context.Profiles.AddAsync(profileModel);
				await _context.SaveChangesAsync();
				if (profileData.Entity.Id < 1)
				{
					return new AddProfileResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding profile."
					};
				}
				else
				{
					var courtsObject = _mapper.Map<AddProfileResponse>(profileData.Entity);
					courtsObject.Successful = true;
					return courtsObject;
				}
			}
			catch (Exception ex)
			{
				return new AddProfileResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding profile. " + ex.Message
				};
			}
		}
	}
}
