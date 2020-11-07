using EasyBooking.Application.CommandAndQuery.Dashboard.Query.GetCategories.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.Dashboard.Query.GetCategories
{
    class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, GetCategoriesResponse>
    {
        private readonly ILogger<GetCategoriesHandler> _logger;
        private readonly AutoMapper.IMapper _mapper;
        private readonly SpeekIOContext _context;
       

        public GetCategoriesHandler(ILogger<GetCategoriesHandler> logger,AutoMapper.IMapper mapper,  SpeekIOContext context)
        {
            this._logger = logger;
            this._mapper = mapper;
            this._context = context;

        }

        public async Task<GetCategoriesResponse> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result =  _context.Sports.Where(x => x.CompanyId == request.CompanyId)
            .Select(x => new GetCategoriesDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
                var totalRecord = result.Count();

                return new GetCategoriesResponse()
                {
                    Successful = true,
                    Message = "Categories are found successfully.",
                    Items = result,
                    TotalCount = totalRecord,
                  
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new GetCategoriesResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while getting Companies. " + ex.Message,
                    TotalCount = 0
                };
            }
        }
    }
}
