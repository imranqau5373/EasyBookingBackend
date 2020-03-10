using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.DeleteCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.DeleteCourtsDuration.Dto;
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
namespace EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.DeleteCourtsDuration
{
    public class DeleteCourtsDurationCommandHandler : CommandHandlerBase<DeleteCourtsDurationCommand, DeleteCourtsDurationResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public DeleteCourtsDurationCommandHandler(ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
            SpeekIOContext context,
            IMapper mapper) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<DeleteCourtsDurationResponse> Handle(DeleteCourtsDurationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _context.CourtsDurations.FindAsync(request.Id);
                if (data.Id < 1)
                {
                    return new DeleteCourtsDurationResponse()
                    {
                        Successful = false,
                        Message = "Record not found."
                    };
                }
                _context.CourtsDurations.Remove(data);
                await _context.SaveChangesAsync(User);

                return new DeleteCourtsDurationResponse()
                {
                    Successful = true,
                    Message = "Booking duration info deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new DeleteCourtsDurationResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while deleting Booking duration info." + ex.Message
                };
            }

        }
    }
}
