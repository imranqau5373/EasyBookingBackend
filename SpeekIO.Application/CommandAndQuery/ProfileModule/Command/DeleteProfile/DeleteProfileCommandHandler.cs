using AutoMapper;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.DeleteProfile.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.DeleteProfile
{
    public class DeleteProfileCommandHandler : CommandHandlerBase<DeleteProfileCommand, DeleteProfileResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public DeleteProfileCommandHandler(
            ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
            SpeekIOContext context,
            IMapper mapper) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<DeleteProfileResponse> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var profile = await _context.Profiles.FindAsync(request.Id);
                if (profile.Id < 1)
                {
                    return new DeleteProfileResponse()
                    {
                        Successful = false,
                        Message = "Record not found."
                    };
                }
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync(User);

                return new DeleteProfileResponse()
                {
                    Successful = true,
                    Message = "profile deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new DeleteProfileResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while deleting profile." + ex.Message
                };
            }

        }
    }
}
