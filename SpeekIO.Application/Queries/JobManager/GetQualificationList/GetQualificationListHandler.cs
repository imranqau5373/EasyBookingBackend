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

namespace SpeekIO.Application.Queries.Job.GetQualificationList
{
    public class GetQualificationListHandler : IRequestHandler<GetQualificationListQuery, GetQualificationListResponse>
    {
        private readonly ILogger<GetQualificationListHandler> _logger;
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public GetQualificationListHandler(
            ILogger<GetQualificationListHandler> logger,
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetQualificationListResponse> Handle(GetQualificationListQuery request, CancellationToken cancellationToken)
        {
            var qualifications = await _context.Qualification.ToListAsync();
            var qualificationList = _mapper.Map<List<GetQualification>>(qualifications);
            var qualificationVM = new GetQualificationListResponse()
            {
                Qualifications = qualificationList,
                Successful = true
            };
            return qualificationVM;
        }
    }
}
