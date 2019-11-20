using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.ViewModels.Response.JobsResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Queries.Job.GetLanguageList
{
    public class GetLanguageListHandler : IRequestHandler<GetLanguageListQuery, GetLanguageListResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public GetLanguageListHandler(
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<GetLanguageListResponse> Handle(GetLanguageListQuery request, CancellationToken cancellationToken)
        {
            var languages = await _context.Language.ToListAsync();
            var languageList = _mapper.Map<List<GetLanguageModel>>(languages);
            var languageResponse = new GetLanguageListResponse()
            {
                Languages = languageList,
                Successful = true
            };
            return languageResponse;
        }
    }
}
