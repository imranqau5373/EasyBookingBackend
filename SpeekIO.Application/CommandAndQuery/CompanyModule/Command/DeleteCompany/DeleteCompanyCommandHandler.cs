using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteCompany.Dto;
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

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, DeleteCompanyResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public DeleteCompanyCommandHandler(
            SpeekIOContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DeleteCompanyResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _context.Companies.FindAsync(request.Id);
                if (company.Id < 1)
                {
                    return new DeleteCompanyResponse()
                    {
                        Successful = false,
                        Message = "Record not found."
                    };
                }
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();

                return new DeleteCompanyResponse()
                {
                    Successful = true,
                    Message = "company deleted successfully."
                };
            }
            catch (Exception ex)
            {
                return new DeleteCompanyResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while deleting company." + ex.Message
                };
            }

        }
    }
}
