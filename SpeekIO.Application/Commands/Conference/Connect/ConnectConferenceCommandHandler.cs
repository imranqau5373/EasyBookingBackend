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
using SpeekIO.Domain.Entities.CommunicationEntities;
using SpeekIO.Domain.Enums.Video;

namespace SpeekIO.Application.Commands.Conference.Connect
{
    public class ConnectConferenceCommandHandler : CommandHandlerBase<ConnectConferenceCommand, ConnectConferenceResponse>
    {
        private readonly ISpeekIODbContext _context;
        private readonly IVideoService _videoService;

        public ConnectConferenceCommandHandler(ApplicationUserManager userManager, IHttpContextAccessor httpContextAccessor,
            ISpeekIODbContext context,
            IVideoService videoService)
            : base(userManager, httpContextAccessor)
        {
            _context = context;
            _videoService = videoService;
        }

        public override async Task<ConnectConferenceResponse> Handle(ConnectConferenceCommand request, CancellationToken cancellationToken)
        {
            var conference = _context.ConferenceSessions.SingleOrDefault(t => t.Id == request.ConferenceId);
            if (null == conference)
                return new ConnectConferenceResponse(false, "Conference not found");

            var profileId = User.Id;
            var participant = _context.Participants.SingleOrDefault(t => t.ConferenceSessionId == request.ConferenceId && t.ProfileId == profileId);

            return await Connect(conference, participant);

        }

        private async Task<ConnectConferenceResponse> Connect(ConferenceSession conference, Participant participant)
        {
            if (null == participant)
            {
                // check if conference has public access then allow this participant
                if (conference.IsPublic)
                {
                    participant = await AddParticipantToConference(conference);
                }
            }

            VideoRole role = VideoRole.PUBLISHER;
            if (conference.IsBroadcast && participant.ParticipantType == Domain.Enums.EntityEnums.ParticipantType.Host)// during broadcast, host can only publish
                role = VideoRole.PUBLISHER;
            else if (conference.IsBroadcast && participant.ParticipantType != Domain.Enums.EntityEnums.ParticipantType.Host) // during broadcast viewer can only subscribe
                role = VideoRole.SUBSCRIBER;
            else if (!conference.IsBroadcast) // during normal video call, everyone is a moderator
                role = VideoRole.MODERATOR;

            var sessionToken = _videoService.CreateNewToken(new Domain.Interfaces.Models.VideoSession()
            {
                Id = conference.SessionIdentifier,
                Role = role
            });

            return new ConnectConferenceResponse()
            {
                AllowRecording = participant.ParticipantType == Domain.Enums.EntityEnums.ParticipantType.Host ? conference.AllowRecordingOfHost : conference.AllowRecordingOfParticipants,
                AutoConnect = conference.AutoAcceptConference,
                AutoRecording = conference.RecordAutomatically,
                Role = role,
                State = conference.State,
                Token = sessionToken.Value
            };

        }

        private async Task<Participant> AddParticipantToConference(ConferenceSession conference)
        {
            var participant = new Participant
            {
                ParticipantType = Domain.Enums.EntityEnums.ParticipantType.Viewer,
                State = Domain.Enums.EntityEnums.ParticipantState.Unknown,
                ProfileId = User.Id,
                ConferenceSession = conference
            };
            conference.Participants.Add(participant);
            await _context.SaveChangesAsync();

            return participant;
        }
    }
}
