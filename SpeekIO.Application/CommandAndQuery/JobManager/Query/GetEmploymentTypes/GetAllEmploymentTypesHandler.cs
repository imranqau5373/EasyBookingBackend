using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.ViewModels.Response.JobsResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Job.GetEmploymentTypes
{
    public class GetAllEmploymentTypesHandler : IRequestHandler<GetAllEmploymentTypesQuery, GetAllEmploymentTypeListViewModel>
    {
        private readonly ILogger<GetAllEmploymentTypesHandler> _logger;
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public GetAllEmploymentTypesHandler(
            ILogger<GetAllEmploymentTypesHandler> logger,
            ISpeekIODbContext context,
            IMapper mapper)
        {
            this._logger = logger;
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetAllEmploymentTypeListViewModel> Handle(GetAllEmploymentTypesQuery request, CancellationToken cancellationToken)
        {
            var types = await _context.EmploymentType.ToListAsync();
            var responseTypes = _mapper.Map<List<GetAllEmploymentTypesResponse>>(types);
            var responseViewModel = new GetAllEmploymentTypeListViewModel()
            {
                EmploymentTypes = responseTypes,
                Successful = true
            };
            return responseViewModel;
        }

    }
}
