using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.DeleteCourtsBooking.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.DeleteCourtsBooking
{
    public class DeleteCourtsBookingCommandHandler : IRequestHandler<DeleteCourtsBookingCommand, DeleteCourtsBookingResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public DeleteCourtsBookingCommandHandler(
            SpeekIOContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteCourtsBookingResponse> Handle(DeleteCourtsBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var booking = await _context.CourtsBookings.FindAsync(request.Id);
                if (booking.Id < 1)
                {
                    return new DeleteCourtsBookingResponse()
                    {
                        Successful = false,
                        Message = "Record not found."
                    };
                }
                _context.CourtsBookings.Remove(booking);
                await _context.SaveChangesAsync();

                return new DeleteCourtsBookingResponse()
                {
                    Successful = true,
                    Message = "booking deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new DeleteCourtsBookingResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while deleting booking." + ex.Message
                };
            }

        }
    }
}
