using SpeekIO.Application.Commands.Conference.ConnectionLog;
using SpeekIO.Application.Commands.Conference.Create;
using SpeekIO.Application.Commands.Identity.Guest;
using SpeekIO.Application.Commands.Identity.SignUp;
using SpeekIO.Application.Configuration;
using SpeekIO.Domain.Entities.CommunicationEntities;
using SpeekIO.Domain.Entities.Identity;
using SpeekIO.Domain.Entities.Portfolio;
using SpeekIO.Domain.Models;
using SpeekIO.Domain.Models.Email;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        private IApplicationConfiguration _applicationConfiguration;

        public MappingProfile(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;

            CreateMap<SignupCommand, ApplicationUser>()
                .ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
                .ForMember(t => t.UserName, m => m.MapFrom(t => t.Email))
                .ForMember(t => t.PhoneNumber, m => m.MapFrom(t => t.Phone));


            CreateMap<SignupCommand, Domain.Entities.Portfolio.Profile>()
                .ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
                .ForMember(t => t.Name, m => m.MapFrom(t => t.ContactName))
                .ForMember(t => t.Phone, m => m.MapFrom(t => t.Phone))
                .ForMember(t => t.Timezone, m => m.MapFrom(t => t.Timezone))
                .ForMember(t => t.OptInNewsletter, m => m.MapFrom(t => t.SubscribeNewsLetter));


            CreateMap<SignupCommand, Domain.Entities.Portfolio.Company>()
                .ForMember(t => t.Name, m => m.MapFrom(t => t.CompanyName))
                .ForMember(t => t.Url, m => m.MapFrom(t => t.CompanyPrivateUrl));

            CreateMap<CreateGuestUserCommand, ApplicationUser>()
                .ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
                .ForMember(t => t.UserName, m => m.MapFrom(t => t.Email));

            CreateMap<ApplicationUser, Domain.Entities.Portfolio.Profile>()
                .ForMember(t => t.User, m => m.MapFrom(t => t));

            CreateMap<CreateConferenceCommand, ConferenceSession>().ReverseMap();

            CreateMap<CreateConferenceCommand, CreateNewSessionModel>()
                .ForMember(t => t.AutoArchive, m => m.MapFrom(t => t.RecordAutomatically));

            CreateMap<ConferenceSession, ConferenceSessionInvitationEmailModel>()
                .ForMember(t => t.ConferenceId, m => m.MapFrom(t => t.Id))
                .ForMember(t => t.ConferenceTitle, m => m.MapFrom(t => t.Title))
                .ForMember(t => t.ScheduledOn, m => m.MapFrom(t => MapNullableTime(t.ScheduledStartTime)))
                .ForMember(t => t.Duration, m => m.MapFrom(t => MapDuration(t.ScheduledStartTime, t.ScheduledEndTime)))
                .ForMember(t => t.domain, m => m.MapFrom(t => CreateDomainUrl(t.Company)));

            CreateMap<ConnectionLogCommand, Connection>();
        }

        private string CreateDomainUrl(Company company)
        {
            if (null == company)
                return $"https://{_applicationConfiguration.Domain}";

            return $"https://{company.SubDomainPrefix}.{_applicationConfiguration.Domain}";
        }

        private string MapDuration(DateTime? scheduledStartTime, DateTime? scheduledEndTime)
        {
            if (null == scheduledEndTime || null == scheduledStartTime)
                return null;
            return (scheduledEndTime - scheduledStartTime)?.ToString(@"hh'h '\:mm'm'") ?? null;
        }

        private string MapNullableTime(DateTime? time)
        {
            return time?.ToString("dd MMM yyyy HH:mm") ?? string.Empty;
        }
    }
}
