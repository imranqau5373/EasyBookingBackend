using MediatR;
using Microsoft.AspNetCore.Http;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SpeekIO.Domain.Entities.CommunicationEntities;

namespace SpeekIO.Application.Commands.Conference.ConnectionLog
{
    public class ConnectionLogCommandHandler : CommandHandlerBase<ConnectionLogCommand, CommonResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IMapper _mapper;

        public ConnectionLogCommandHandler(ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
            ISpeekIODbContext context,
            AutoMapper.IMapper mapper) : base(userManager, httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<CommonResponse> Handle(ConnectionLogCommand request, CancellationToken cancellationToken)
        {
            var conference = _context.ConferenceSessions.SingleOrDefault(t => t.Id == request.ConferenceId);
            if (null == conference)
                return new CommonResponse(false, "Conference not found");

            var profileId = User.Id;
            var participant = _context.Participants.Include(t => t.Connections).SingleOrDefault(t => t.ConferenceSessionId == request.ConferenceId && t.ProfileId == profileId);
            if (null == participant)
                return new CommonResponse(false, "Participant not found. Reconnect");

            foreach (var connection in participant.Connections)
            {
                connection.State = Domain.Enums.EntityEnums.ConnectionState.Disconnected;
            }

            var newConnectionInformation = _mapper.Map<Connection>(request);
            participant.Connections.Add(newConnectionInformation);

            await _context.SaveChangesAsync();

            return new CommonResponse
            {
                Successful = true,
                Message = "Added connection information successfully"
            };
        }
    }
}
