using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.DeleteCompany.Dto;
using EasyBooking.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Commands;
using SpeekIO.Domain.Entities.Identity;
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
    public class DeleteCompanyCommandHandler : CommandHandlerBase<DeleteCompanyCommand, DeleteCompanyResponse>
    {
        private readonly SpeekIOContext _context;
        private readonly IMapper _mapper;
        public DeleteCompanyCommandHandler(
            ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
            SpeekIOContext context,
            IMapper mapper) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<DeleteCompanyResponse> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
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
                await _context.SaveChangesAsync(User);

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
