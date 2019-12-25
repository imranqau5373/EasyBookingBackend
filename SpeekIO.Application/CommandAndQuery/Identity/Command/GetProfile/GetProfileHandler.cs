using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response.IdentityResponse.QueryResponse;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpeekIO.Application.Commands.Identity.GetProfile
{
    public class GetProfileHandler : CommandHandlerBase<GetProfileCommand, GetProfileResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public GetProfileHandler(
			SpeekIOContext context,
            IMapper mapper,
            ApplicationUserManager userManager,
            IHttpContextAccessor httpContextAccessor) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<GetProfileResponse> Handle(GetProfileCommand request, CancellationToken cancellationToken)
        {
            var userId = User.Id;
            var profile = await _context.Profiles.FirstOrDefaultAsync(t => t.User.Id == userId);
            if(profile == null)
            {
                return new GetProfileResponse()
                {
                    Successful = false,
                    Message = "User not found."
                };
            }
            var response = _mapper.Map<GetProfileResponse>(profile);
            response.Successful = true;
            return response;
        }
    }
}
