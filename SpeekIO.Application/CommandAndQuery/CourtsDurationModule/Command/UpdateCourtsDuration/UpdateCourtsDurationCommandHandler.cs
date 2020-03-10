using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration.Dto;
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
using System.Linq;
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
                if (data != null)
                {
                   if(_context.CourtsBookings
                        .Any(x=> x.CourtsId == request.CourtId && x.IsBooked == true &&
                           ((request.CourtStartTime >= x.BookingStartTime && request.CourtStartTime <= x.BookingEndTime) ||
                           (request.CourtEndTime >= x.BookingStartTime && request.CourtEndTime <= x.BookingEndTime))))
                    {
                        data.Id = 0;
                    }
                    else
                    {
                        _context.Entry(data).State = EntityState.Detached;
                        data = _mapper.Map<CourtsDurations>(request);
                        _context.Entry(data).State = EntityState.Modified;
                        calculateSlots(request);
                        await _context.SaveChangesAsync(User);
                    }
                }
               
                if(data.Id < 1)
                {
                    return new UpdateCourtsDurationResponse()
                    {
                        Successful = false,
                        Message = "There are booking associated with this court, can't proceed with update."
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
        //calcute number of slots
        public void calculateSlots(UpdateCourtsDurationCommand request)
        {
            var startTime = request.CourtStartTime.Value.Hour;
            var endTime = request.CourtEndTime.Value.Hour;
            var totalSlots = 0;
            //chk for -tvie
            totalSlots = ((endTime - startTime) * 60) / request.SlotDuration;
            addBooking(totalSlots, request);
        }
        //add court bookings
        public void addBooking(int slotsCount, UpdateCourtsDurationCommand request)
        {
            AddCourtsBookingCommand data = new AddCourtsBookingCommand();
            var startTime = request.CourtStartTime;
            var slotDuration = request.SlotDuration;
            for (int i = 0; i < slotsCount; i++)
            {
                data.CourtId = request.CourtId;
                data.Name = request.Name;
                data.Description = request.Description;
                data.IsBooked = false;
                data.IsEmailed = false;
                data.BookingStartTime = startTime;
                var endTime = startTime.Value.AddMinutes(slotDuration);
                data.BookingEndTime = endTime;

                var model = _mapper.Map<CourtBookings>(data);
                var entity = _context.CourtsBookings
                       .Where(x => x.CourtsId == request.CourtId && x.IsBooked == false &&
                          ((data.BookingStartTime > x.BookingStartTime && data.BookingStartTime < x.BookingEndTime) ||
                          (data.BookingEndTime > x.BookingStartTime && data.BookingEndTime < x.BookingEndTime))).FirstOrDefault();
                if (entity!=null)
                {
                    _context.CourtsBookings.Remove(entity);
                     _context.SaveChanges();

                    _context.CourtsBookings.AddAsync(model);
                    //_context.Entry(entity).State = EntityState.Detached;
                    //entity = _mapper.Map<CourtBookings>(data);
                    //_context.Entry(entity).State = EntityState.Modified;
                }
                else
                {
                    _context.CourtsBookings.AddAsync(model);
                }                   
                startTime = endTime;
            }
        }
    }
}
