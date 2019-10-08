using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using SpeekIO.Application.Interfaces;
using SpeekIO.Domain.Entities.CommunicationEntities;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Enums.IdentityEnums;
using SpeekIO.Domain.ViewModels.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Models;
using SpeekIO.Application.Commands.Identity.Guest;
using Microsoft.EntityFrameworkCore;
using SpeekIO.Domain.Models.Email;
using SpeekIO.Domain.Intefaces.Email;

namespace SpeekIO.Application.Commands.Conference.Create
{
    public class CreateConferenceCommandHandler : CommandHandlerBase<CreateConferenceCommand, ConferenceResponse>
    {
        private readonly IMediator _mediator;
        private readonly AutoMapper.IMapper _mapper;
        private readonly ISpeekIODbContext _context;
        private readonly IEmailService _emailService;
        private readonly IVideoService _videoService;
        private readonly ILogger<CreateConferenceCommandHandler> _logger;

        private CreateConferenceCommand _command;
        private Profile _hostProfile;
        private Company _company;

        public CreateConferenceCommandHandler(AutoMapper.IMapper mapper,
              IMediator mediator,
              ISpeekIODbContext context,
              IEmailService emailService,
              IVideoService videoService,
              ApplicationUserManager userManager,
              IHttpContextAccessor httpContextAccessor,
              ILogger<CreateConferenceCommandHandler> logger) : base(userManager, httpContextAccessor)
        {
            _mediator = mediator;
            _mapper = mapper;
            _context = context;
            _emailService = emailService;
            _videoService = videoService;
            _logger = logger;
        }
        public override async Task<ConferenceResponse> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _command = request;

                _logger.LogInformation("Creating new conference session");

                if (!(await CanCreateConference()))
                {
                    return new ConferenceResponse
                    {
                        Successful = false,
                        Message = "User is not authorized to create conference"
                    };
                }

                FetchUserProfile();

                if (string.IsNullOrWhiteSpace(_company.SubDomainPrefix))
                    throw new Exception($"Company is not yet available on subdomain. Please register Company: {_company.Name} with a subdomain to create conference sessions");

                var conference = await SetupConference();
                await SetupHost(conference);
                await SetupParticipants(conference);

                await SendInvitationEmails(conference);

                return new ConferenceResponse
                {
                    Successful = true
                };
            }
            catch (Exception e)
            {
                _logger.LogError("Error occured while creating conference session", e);
                throw;
            }
        }

        private async Task SendInvitationEmails(ConferenceSession conference)
        {
            var participants = await _context.Participants.Where(t => t.ParticipantType == Domain.Enums.EntityEnums.ParticipantType.Viewer).ToListAsync();

            ConferenceSessionInvitationEmailModel emailModel = _mapper.Map<ConferenceSessionInvitationEmailModel>(conference);
            emailModel.ScheduledBy = _hostProfile.Name ?? _hostProfile.Email;
            emailModel.Emails = _command.ParticipantEmails;

            await _emailService.SendEmailAsync(emailModel);
        }

        private async Task SetupParticipants(ConferenceSession conference)
        {
            foreach (var email in _command.ParticipantEmails ?? new List<string>())
            {
                var applicationUser = await _userManager.FindByEmailAsync(email);
                Profile profile = null;
                if (null == applicationUser)
                    (applicationUser, profile) = await CreateGuestUser(email);
                else
                    profile = await _context.Profiles.SingleOrDefaultAsync(t => t.Id == applicationUser.Id);

                if (null != applicationUser && null != profile)
                {
                    var participant = new Participant
                    {
                        ParticipantType = Domain.Enums.EntityEnums.ParticipantType.Viewer,
                        State = Domain.Enums.EntityEnums.ParticipantState.Invited,
                        Profile = profile
                    };

                    conference.Participants.Add(participant);
                }
            }

            await _context.SaveChangesAsync();
        }

        private async Task<(ApplicationUser applicationUser, Profile profile)> CreateGuestUser(string email)
        {
            var guestResponse = await _mediator.Send(new CreateGuestUserCommand(email));
            if (guestResponse.Successful || guestResponse.AlreadyExists)
            {
                var applicationUser = await _userManager.FindByEmailAsync(email);
                var profile = _context.Profiles.SingleOrDefault(t => t.Id == applicationUser.Id);
                return (applicationUser, profile);
            }
            return (null, null);
        }

        private async Task SetupHost(ConferenceSession conference)
        {
            var participant = new Participant
            {
                ParticipantType = Domain.Enums.EntityEnums.ParticipantType.Host,
                State = Domain.Enums.EntityEnums.ParticipantState.Invited,
                Profile = _hostProfile
            };

            conference.Participants.Add(participant);
            await _context.SaveChangesAsync();
        }

        private async Task<ConferenceSession> SetupConference()
        {
            var sessionResponse = _videoService.CreateNewSession(_mapper.Map<CreateNewSessionModel>(_command));

            var conferenceSession = _mapper.Map<ConferenceSession>(_command);
            conferenceSession.SessionIdentifier = sessionResponse.Id;
            conferenceSession.Company = _company;

            await _context.ConferenceSessions.AddAsync(conferenceSession);
            await _context.SaveChangesAsync();

            return conferenceSession;
        }
        private void FetchUserProfile()
        {
            _hostProfile = _context.Profiles.Include(t => t.Company).SingleOrDefault(t => t.Id == User.Id);
            _company = _hostProfile.Company;
        }


        private async Task<bool> CanCreateConference()
        {
            return (await _userManager.IsInRoleAsync(User, UserRoles.Admin.ToString())
                 || await _userManager.IsInRoleAsync(User, UserRoles.HRManager.ToString()))
                 && await _userManager.IsInRoleAsync(User, UserRoles.User.ToString());
        }
    }
}
