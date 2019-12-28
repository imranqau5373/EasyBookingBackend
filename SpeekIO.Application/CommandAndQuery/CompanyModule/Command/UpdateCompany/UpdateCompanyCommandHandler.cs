using AutoMapper;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto;
using EasyBooking.Domain.Entities;
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

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany
{
    public class UpdateCompanyCommandHandler : CommandHandlerBase<UpdateCompanyCommand, UpdateCompanyResponse>
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
        public override async Task<UpdateCompanyResponse> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var company = await _context.Companies.FindAsync(request.Id);
                _context.Entry(company).State = EntityState.Detached;
                company = _mapper.Map<Company>(request);
                _context.Entry(company).State = EntityState.Modified;
                await _context.SaveChangesAsync(User);
                if(company.Id < 1)
                {
                    return new UpdateCompanyResponse()
                    {
                        Successful = false,
                        Message = "Something went wrong while updating company."
                    };                    
                }
                return new UpdateCompanyResponse()
                {
                    Successful = true,
                    Message = "company updated successfully."
                };
            }
            catch(Exception e)
            {
                return new UpdateCompanyResponse()
                {
                    Successful = false,
                    Message = "Something went wrong while updating company." + e.Message
                };
            }
        }
    }
}
