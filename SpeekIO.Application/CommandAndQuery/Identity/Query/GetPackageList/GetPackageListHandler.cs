using AutoMapper;
using EasyBooking.Application.CommandAndQuery.Identity.Query.GetPackageList.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Presistence.Context;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.Identity.Query.GetPackageList
{
	public class GetPackageListHandler : IRequestHandler<GetPackageListQuery, GetPackageListResponse>
	{
		private readonly SpeekIOContext _context;
		private readonly IMapper _mapper;
		public GetPackageListHandler(
			SpeekIOContext context,
			IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task<GetPackageListResponse> Handle(GetPackageListQuery request, CancellationToken cancellationToken)
		{
			var packages = await _context.Package.Select(x => new GetPackageListModel
			{
				Id = x.Id,
				Name = x.Name,
				Charges = x.Charges,
				Description = x.Description,
				ExpiryDays = x.ExpiryDays,
				isActive = x.isActive
			}).ToListAsync();
			return new GetPackageListResponse()
			{
				Successful = true,
				PackageList = packages
			};
		}
	}
}
