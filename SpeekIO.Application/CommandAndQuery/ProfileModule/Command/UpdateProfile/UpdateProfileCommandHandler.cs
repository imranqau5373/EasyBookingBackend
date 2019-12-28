using AutoMapper;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.UpdateProfile.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Application.Configuration;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.UpdateProfile
{
    public class UpdateProfileCommandHandler : CommandHandlerBase<UpdateProfileCommand, UpdateProfileResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public UpdateProfileCommandHandler(
            SpeekIOContext context, IMapper mapper, IApplicationConfiguration applicationConfiguration,
            ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<UpdateProfileResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await _context.Profiles.FindAsync(request.Id);
                _context.Entry(profile).State = EntityState.Detached;
                profile = _mapper.Map<SpeekIO.Domain.Entities.Portfolio.Profile>(request);
                _context.Entry(profile).State = EntityState.Modified;
                await _context.SaveChangesAsync(User);
                if(profile.Id < 1)
                {
                    return new UpdateProfileResponse()
                    {
                        Successful = false,
                        Message = "Something went wrong while updating profile."
                    };                    
                }
                return new UpdateProfileResponse()
                {
                    Successful = true,
                    Message = "profile updated successfully."
                };
            }
            catch(Exception e)
            {
                return new UpdateProfileResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while updating profile." + e.Message
                };
            }
        }
    }
}
