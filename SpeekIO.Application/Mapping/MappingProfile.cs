
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports.Dto;
using EasyBooking.Domain.Entities;
using SpeekIO.Application.Commands.Identity.Guest;
using SpeekIO.Application.Commands.Identity.SignUp;
using SpeekIO.Application.Configuration;

using SpeekIO.Domain.Entities.Identity;

using SpeekIO.Domain.Entities.Portfolio;

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
                .ForMember(t => t.FirstName, m => m.MapFrom(t => t.FirstName))
                .ForMember(t => t.LastName, m => m.MapFrom(t => t.LastName))
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

			#region Sports Mapping

			//Create Sports Mapping

			CreateMap<AddSportsCommand, Sports>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));


			CreateMap<Sports, AddSportsResponse>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));

			//Update Sports Mappings.



			// Delete Sports Mappings.

			// Get Sports Mappings.

			CreateMap<Sports, GetSportsResponse>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));

			// Get All Sports Mappings.





			#endregion



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
