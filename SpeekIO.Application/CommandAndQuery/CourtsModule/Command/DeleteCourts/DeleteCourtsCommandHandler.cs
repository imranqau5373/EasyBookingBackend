using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.DeleteCourts.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.Dto.DeleteCourts;
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

namespace EasyBooking.Application.CommandAndQuery.CourtsModule.Command.DeleteCourts
{
    public class DeleteCourtsCommandHandler : IRequestHandler<DeleteCourtsCommand, DeleteCourtsResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public DeleteCourtsCommandHandler(
            SpeekIOContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteCourtsResponse> Handle(DeleteCourtsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var courts = await _context.Courts.FindAsync(request.Id);
                if (courts.Id < 1)
                {
                    return new DeleteCourtsResponse()
                    {
                        Successful = false,
                        Message = "Record not found."
                    };
                }
                _context.Courts.Remove(courts);
                await _context.SaveChangesAsync();

                //var court = new Courts() { Id = request.Id };
                //_context.Courts.Attach(court);
                //_context.Courts.Remove(court);
                return new DeleteCourtsResponse()
                {
                    Successful = true,
                    Message = "court deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new DeleteCourtsResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while deleting court." + ex.Message
                };
            }

        }
    }
}
