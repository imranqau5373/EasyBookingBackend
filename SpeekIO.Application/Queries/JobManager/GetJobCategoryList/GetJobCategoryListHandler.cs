using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.ViewModels.Response.JobsResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Job.GetJobCategoryList
{
    public class GetJobCategoryListHandler : IRequestHandler<GetJobCategoryListQuery, GetJobCategoryListResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public GetJobCategoryListHandler(
            ILogger<GetJobCategoryListHandler> logger,
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetJobCategoryListResponse> Handle(GetJobCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _context.JobCategory.ToListAsync();
            var categoryList = _mapper.Map<List<GetJobCategory>>(categories);
            var categoryListVM = new GetJobCategoryListResponse()
            {
                JobCategories = categoryList,
                Successful = true
            };
            return categoryListVM;
        }
    }
}
