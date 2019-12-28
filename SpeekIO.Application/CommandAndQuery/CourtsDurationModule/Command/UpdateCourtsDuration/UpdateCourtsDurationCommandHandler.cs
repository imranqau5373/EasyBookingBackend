using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.UpdateCourtsDuration.Dto;
using EasyBooking.Domain.Entities;
using EasyBooking.Domain.Entities.Bookings;
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

namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.UpdateCourtsDuration
{
    public class UpdateCompanyCommandHandler : CommandHandlerBase<UpdateCourtsDurationCommand, UpdateCourtsDurationResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public UpdateCompanyCommandHandler(
            SpeekIOContext context, IMapper mapper, IApplicationConfiguration applicationConfiguration,
            ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }
        public override async Task<UpdateCourtsDurationResponse> Handle(UpdateCourtsDurationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.CourtsDurations.FindAsync(request.Id);
                _context.Entry(data).State = EntityState.Detached;
                data = _mapper.Map<CourtsDurations>(request);
                _context.Entry(data).State = EntityState.Modified;
                await _context.SaveChangesAsync(User);
                if(data.Id < 1)
                {
                    return new UpdateCourtsDurationResponse()
                    {
                        Successful = false,
                        Message = "Something went wrong while updating courts duration."
                    };                    
                }
                return new UpdateCourtsDurationResponse()
                {
                    Successful = true,
                    Message = "courts duration updated successfully."
                };
            }
            catch(Exception e)
            {
                return new UpdateCourtsDurationResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while updating durations." + e.Message
                };
            }
        }
    }
}
