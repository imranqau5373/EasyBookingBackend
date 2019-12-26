using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.UpdateCourts.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Application.Commands;
using SpeekIO.Application.Configuration;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Presistence.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.UpdateCourts
{
    public class UpdateCourtsCommandHandler : CommandHandlerBase<UpdateCourtsCommand, UpdateCourtsResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public UpdateCourtsCommandHandler(
            SpeekIOContext context, IMapper mapper, IApplicationConfiguration applicationConfiguration,
            ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<UpdateCourtsResponse> Handle(UpdateCourtsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var courts = await _context.Courts.FindAsync(request.Id);
                _context.Entry(courts).State = EntityState.Detached;
                courts = _mapper.Map<Courts>(request);
                _context.Entry(courts).State = EntityState.Modified;
                await _context.SaveChangesAsync(User);
                if(courts.Id < 1)
                {
                    return new UpdateCourtsResponse()
                    {
                        Successful = false,
                        Message = "Something went wrong while updating courts."
                    };                    
                }
                return new UpdateCourtsResponse()
                {
                    Successful = true,
                    Message = "courts updated successfully."
                };
            }
            catch(Exception e)
            {
                return new UpdateCourtsResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while updating courts." + e.Message
                };
            }
        }
    }
}
