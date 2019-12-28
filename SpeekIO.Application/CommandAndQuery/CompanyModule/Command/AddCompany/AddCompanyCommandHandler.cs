using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany
{
    public class AddCompanyCommandHandler : IRequestHandler<AddCompanyCommand, AddCompanyResponse>
	{


		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public AddCompanyCommandHandler(
			SpeekIOContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<AddCompanyResponse> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
		{
			try
			{
				var companyModel = _mapper.Map<Company>(request);
				var companyData = await _context.Companies.AddAsync(companyModel);
				await _context.SaveChangesAsync();
				if (companyData.Entity.Id < 1)
				{
					return new AddCompanyResponse()
					{
						Successful = false,
						Message = "Something went wrong while adding comany."
					};
				}
				else
				{
					var courtsObject = _mapper.Map<AddCompanyResponse>(companyData.Entity);
					courtsObject.Successful = true;
					return courtsObject;
				}
			}
			catch (Exception ex)
			{
				return new AddCompanyResponse()
				{
					Successful = false,
					Message = "Something went wrong while adding comany. " + ex.Message
				};
			}
		}
	}
}
