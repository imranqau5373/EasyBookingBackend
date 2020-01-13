using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteSports.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteSports
{
    public class DeleteSportsCommandHandler : IRequestHandler<DeleteSportsCommand, DeleteSportsResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public DeleteSportsCommandHandler(
            SpeekIOContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteSportsResponse> Handle(DeleteSportsCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sport = await _context.Sports.FindAsync(request.Id);
                if (sport.Id < 1)
                {
                    return new DeleteSportsResponse()
                    {
                        Successful = false,
                        Message = "Record not found."
                    };
                }
                _context.Sports.Remove(sport);
                await _context.SaveChangesAsync();

                return new DeleteSportsResponse()
                {
                    Successful = true,
                    Message = "sport deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new DeleteSportsResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while deleting sport." + ex.Message
                };
            }

        }
    }
}
