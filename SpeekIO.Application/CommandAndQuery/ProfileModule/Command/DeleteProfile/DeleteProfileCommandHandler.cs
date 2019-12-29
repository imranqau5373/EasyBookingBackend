using AutoMapper;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.DeleteProfile.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.ProfileModule.Command.DeleteProfile
{
    public class DeleteProfileCommandHandler : IRequestHandler<DeleteProfileCommand, DeleteProfileResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;
        public DeleteProfileCommandHandler(
            ISpeekIODbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteProfileResponse> Handle(DeleteProfileCommand request, CancellationToken cancellationToken)
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
                await _context.SaveChangesAsync();

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
