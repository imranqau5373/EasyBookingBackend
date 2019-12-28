using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking
{
    public class UpdateCompanyCommandHandler : CommandHandlerBase<UpdateCourtsBookingCommand, UpdateCourtsBookingResponse>
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
        public override async Task<UpdateCourtsBookingResponse> Handle(UpdateCourtsBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var bookings = await _context.CourtsBookings.FindAsync(request.Id);
                _context.Entry(bookings).State = EntityState.Detached;
                bookings = _mapper.Map<CourtBookings>(request);
                _context.Entry(bookings).State = EntityState.Modified;
                await _context.SaveChangesAsync(User);
                if(bookings.Id < 1)
                {
                    return new UpdateCourtsBookingResponse()
                    {
                        Successful = false,
                        Message = "Something went wrong while updating company."
                    };                    
                }
                return new UpdateCourtsBookingResponse()
                {
                    Successful = true,
                    Message = "company updated successfully."
                };
            }
            catch(Exception e)
            {
                return new UpdateCourtsBookingResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while updating company." + e.Message
                };
            }
        }
    }
}
