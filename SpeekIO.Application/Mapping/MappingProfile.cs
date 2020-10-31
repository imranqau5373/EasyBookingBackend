
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.AddCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Command.UpdateCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompany.Dto;
using EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompanyList.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.AddCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Command.UpdateCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsBookingModule.Query.GetCourtsBooking.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.AddCourtsDuration.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Command.UpdateCourtsDuration.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsDurationModule.Query.GetCourtsDuration.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.AddCourts.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.Dto.DeleteCourts;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Command.UpdateCourts.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourts.Dto;
using EasyBooking.Application.CommandAndQuery.CourtsModule.Query.GetCourtsList.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddDayTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.AddTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Command.UpdateDayTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedule.Dto;
using EasyBooking.Application.CommandAndQuery.DayTimeScheduleModule.Query.GetDayTimeSchedules.Dto;
using EasyBooking.Application.CommandAndQuery.Identity.Command.AddGuestUser;
using EasyBooking.Application.CommandAndQuery.Identity.Command.AddUser.Dto;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.AddProfile.Dto;
///using EasyBooking.Application.CommandAndQuery.ProfileModule.Command.UpdateProfile.Dto;
using EasyBooking.Application.CommandAndQuery.ProfileModule.Query.GetProfile.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.AddSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Command.UpdateSports.Dto;
using EasyBooking.Application.CommandAndQuery.Sports_Module.Query.GetSports.Dto;
using EasyBooking.Domain.Entities;
using EasyBooking.Domain.Entities.Bookings;
using SpeekIO.Application.Commands.Identity.Guest;
using SpeekIO.Application.Commands.Identity.SignUp;
using SpeekIO.Application.Commands.Identity.UpdateProfile;
using SpeekIO.Application.Configuration;

using SpeekIO.Domain.Entities.Identity;

using SpeekIO.Domain.Entities.Portfolio;

using System;

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
                .ForMember(t => t.PackageId, m => m.MapFrom(t => t.PackageId))
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
			CreateMap<UpdateSportsCommand, Sports>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));
			// Delete Sports Mappings.

			// Get Sports Mappings.

			CreateMap<Sports, GetSportsResponse>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));

			// Get All Sports Mappings.





			#endregion
			#region Courts Mappings

			//Create Courts Mapping
			CreateMap<AddCourtsCommand, Courts>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
				.ForMember(t => t.SportsId, m => m.MapFrom(t => t.SportsId));
			CreateMap<Courts, AddCourtsResponse>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
				.ForMember(t => t.SportsId, m => m.MapFrom(t => t.SportsId));
			//Update Courts Mapping
			CreateMap<UpdateCourtsCommand, Courts>()
			  .ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
			  .ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
			  .ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
			  .ForMember(t => t.SportsId, m => m.MapFrom(t => t.SportsId));
			//Delete Courts Command
			CreateMap<DeleteCourtsCommand, Courts>()
			  .ForMember(t => t.Id, m => m.MapFrom(t => t.Id));
			//Get Courts Query
			CreateMap<Courts, GetCourtsResponse>()
			 .ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
			 .ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
			 .ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
			 .ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
			 .ForMember(t => t.SportsId, m => m.MapFrom(t => t.SportsId));
			//Get Courts list query
			CreateMap<Courts, GetCourtsListDto>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description));

			#endregion
			#region Company Mappings
			//Create Company Mapping
			CreateMap<AddCompanyCommand, Company>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Url, m => m.MapFrom(t => t.Url))
				.ForMember(t => t.PackageId, m => m.MapFrom(t => t.PackageId))
				.ForMember(t => t.SubDomainPrefix, m => m.MapFrom(t => t.SubDomainPrefix));
			CreateMap<Company, AddCompanyResponse>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Url, m => m.MapFrom(t => t.Url))
				.ForMember(t => t.SubDomainPrefix, m => m.MapFrom(t => t.SubDomainPrefix));
			//Update Company Mapping
			CreateMap<UpdateCompanyCommand, Company>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
			  	.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Url, m => m.MapFrom(t => t.Url))
				.ForMember(t => t.PackageId, m => m.MapFrom(t => t.PackageId))
				.ForMember(t => t.SubDomainPrefix, m => m.MapFrom(t => t.SubDomainPrefix));
			//Get Company Query
			CreateMap<Company, GetCompanyResponse>()
			    .ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
			    .ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.PackageId, m => m.MapFrom(t => t.PackageId))
				.ForMember(t => t.Url, m => m.MapFrom(t => t.Url))
				.ForMember(t => t.SubDomainPrefix, m => m.MapFrom(t => t.SubDomainPrefix));
			//Get Company List Mappings
			CreateMap<Company, GetCompanyListDto>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.PackageId, m => m.MapFrom(t => t.PackageId))
				.ForMember(t => t.Url, m => m.MapFrom(t => t.Url))
				.ForMember(t => t.SubDomainPrefix, m => m.MapFrom(t => t.SubDomainPrefix));

			#endregion
			#region Profile Mappings
			//Create Profile Mapping
			CreateMap<AddProfileCommand, Profile>()
				.ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.FirstName, m => m.MapFrom(t => t.FirstName))
				.ForMember(t => t.LastName, m => m.MapFrom(t => t.LastName))
				.ForMember(t => t.Phone, m => m.MapFrom(t => t.Phone))
				.ForMember(t => t.PictureUrl, m => m.MapFrom(t => t.PictureUrl))
				.ForMember(t => t.PictureThumbnailUrl, m => m.MapFrom(t => t.PictureThumbnailUrl))
				.ForMember(t => t.Timezone, m => m.MapFrom(t => t.Timezone))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
				.ForMember(t => t.OptInNewsletter, m => m.MapFrom(t => t.OptInNewsletter));

			CreateMap<Profile, AddProfileResponse>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.FirstName, m => m.MapFrom(t => t.FirstName))
				.ForMember(t => t.LastName, m => m.MapFrom(t => t.LastName))
				.ForMember(t => t.Phone, m => m.MapFrom(t => t.Phone))
				.ForMember(t => t.PictureUrl, m => m.MapFrom(t => t.PictureUrl))
				.ForMember(t => t.PictureThumbnailUrl, m => m.MapFrom(t => t.PictureThumbnailUrl))
				.ForMember(t => t.Timezone, m => m.MapFrom(t => t.Timezone))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
				.ForMember(t => t.OptInNewsletter, m => m.MapFrom(t => t.OptInNewsletter));
			//Update Profile Mapping
			CreateMap<UpdateProfileCommand, Profile>()
				//.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
				//.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.FirstName, m => m.MapFrom(t => t.FirstName))
				.ForMember(t => t.LastName, m => m.MapFrom(t => t.LastName))
				.ForMember(t => t.Phone, m => m.MapFrom(t => t.Phone))
				.ForMember(t => t.PictureUrl, m => m.MapFrom(t => t.ProfilePicture));
				//.ForMember(t => t.PictureThumbnailUrl, m => m.MapFrom(t => t.PictureThumbnailUrl))
				//.ForMember(t => t.Timezone, m => m.MapFrom(t => t.Timezone))
				//.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
				//.ForMember(t => t.OptInNewsletter, m => m.MapFrom(t => t.OptInNewsletter));
			//Get Profile Query
			CreateMap<Profile, GetProfileResponse>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.FirstName, m => m.MapFrom(t => t.FirstName))
				.ForMember(t => t.LastName, m => m.MapFrom(t => t.LastName))
				.ForMember(t => t.Phone, m => m.MapFrom(t => t.Phone))
				.ForMember(t => t.PictureUrl, m => m.MapFrom(t => t.PictureUrl))
				.ForMember(t => t.PictureThumbnailUrl, m => m.MapFrom(t => t.PictureThumbnailUrl))
				.ForMember(t => t.Timezone, m => m.MapFrom(t => t.Timezone))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
				.ForMember(t => t.OptInNewsletter, m => m.MapFrom(t => t.OptInNewsletter));
			//Get Profile List Mappings
			CreateMap<Profile, GetProfileListDto>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Email, m => m.MapFrom(t => t.Email))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.FirstName, m => m.MapFrom(t => t.FirstName))
				.ForMember(t => t.LastName, m => m.MapFrom(t => t.LastName))
				.ForMember(t => t.Phone, m => m.MapFrom(t => t.Phone))
				.ForMember(t => t.PictureUrl, m => m.MapFrom(t => t.PictureUrl))
				.ForMember(t => t.PictureThumbnailUrl, m => m.MapFrom(t => t.PictureThumbnailUrl))
				.ForMember(t => t.Timezone, m => m.MapFrom(t => t.Timezone))
				.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId))
				.ForMember(t => t.OptInNewsletter, m => m.MapFrom(t => t.OptInNewsletter));

			CreateMap<AddUserCommand, ApplicationUser>().ReverseMap();
			CreateMap<AddGuestUserCommand, ApplicationUser>().ReverseMap();
			CreateMap<AddUserCommand, Profile>().ReverseMap();
			CreateMap<AddGuestUserCommand, Profile>().ReverseMap();

			#endregion
			#region Booking Mappings
			//Create CourtsBooking Mapping
			CreateMap<AddCourtsBookingCommand, CourtBookings>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtsId, m => m.MapFrom(t => t.CourtId))
				.ForMember(t => t.UserId, m => m.MapFrom(t => t.UserId))
				.ForMember(t => t.BookingStartTime, m => m.MapFrom(t => t.BookingStartTime))
				.ForMember(t => t.BookingEndTime, m => m.MapFrom(t => t.BookingEndTime))
				.ForMember(t => t.IsBooked, m => m.MapFrom(t => t.IsBooked))
				.ForMember(t => t.IsEmailed, m => m.MapFrom(t => t.IsEmailed));

			CreateMap<CourtBookings, AddCourtsBookingResponse>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtId, m => m.MapFrom(t => t.CourtsId))
				.ForMember(t => t.UserId, m => m.MapFrom(t => t.UserId))
				.ForMember(t => t.BookingStartTime, m => m.MapFrom(t => t.BookingStartTime))
				.ForMember(t => t.BookingEndTime, m => m.MapFrom(t => t.BookingEndTime))
				.ForMember(t => t.IsBooked, m => m.MapFrom(t => t.IsBooked))
				.ForMember(t => t.IsEmailed, m => m.MapFrom(t => t.IsEmailed));
			//Update CourtBookings Mapping
			CreateMap<UpdateCourtsBookingCommand, CourtBookings>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtsId, m => m.MapFrom(t => t.CourtId))
				.ForMember(t => t.UserId, m => m.MapFrom(t => t.UserId))
				.ForMember(t => t.BookingStartTime, m => m.MapFrom(t => t.BookingStartTime))
				.ForMember(t => t.BookingEndTime, m => m.MapFrom(t => t.BookingEndTime))
				.ForMember(t => t.IsBooked, m => m.MapFrom(t => t.IsBooked))
				.ForMember(t => t.IsEmailed, m => m.MapFrom(t => t.IsEmailed));
			//Get CourtBookings Query
			CreateMap<CourtBookings, GetCourtsBookingResponse>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtId, m => m.MapFrom(t => t.CourtsId))
				.ForMember(t => t.UserId, m => m.MapFrom(t => t.UserId))
				.ForMember(t => t.BookingStartTime, m => m.MapFrom(t => t.BookingStartTime))
				.ForMember(t => t.BookingEndTime, m => m.MapFrom(t => t.BookingEndTime))
				.ForMember(t => t.IsBooked, m => m.MapFrom(t => t.IsBooked))
				.ForMember(t => t.IsEmailed, m => m.MapFrom(t => t.IsEmailed));

			#endregion
			#region Duration Mappings
			//Create Courts Durations Mapping
			CreateMap<AddCourtsDurationCommand, CourtsDurations>()
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtsId, m => m.MapFrom(t => t.CourtId))
				.ForMember(t => t.DurationStatusId, m => m.MapFrom(t => t.DurationStatusId))
				.ForMember(t => t.CourtStartTime, m => m.MapFrom(t => t.CourtStartTime))
				.ForMember(t => t.CourtEndTime, m => m.MapFrom(t => t.CourtEndTime))
				.ForMember(t => t.SlotDuration, m => m.MapFrom(t => t.SlotDuration));
				//.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));

			CreateMap<CourtsDurations, AddCourtsDurationResponse>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtId, m => m.MapFrom(t => t.CourtsId))
				.ForMember(t => t.CourtStartTime, m => m.MapFrom(t => t.CourtStartTime))
				.ForMember(t => t.CourtEndTime, m => m.MapFrom(t => t.CourtEndTime))
				.ForMember(t => t.SlotDuration, m => m.MapFrom(t => t.SlotDuration));
			//.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));
			//Update CourtBookings Mapping
			CreateMap<UpdateCourtsDurationCommand, CourtsDurations>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtsId, m => m.MapFrom(t => t.CourtId))
				.ForMember(t => t.CourtStartTime, m => m.MapFrom(t => t.CourtStartTime))
				.ForMember(t => t.CourtEndTime, m => m.MapFrom(t => t.CourtEndTime))
				.ForMember(t => t.SlotDuration, m => m.MapFrom(t => t.SlotDuration));
			//.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));
			//Get CourtBookings Query
			CreateMap<CourtsDurations, GetCourtsDurationResponse>()
				.ForMember(t => t.Id, m => m.MapFrom(t => t.Id))
				.ForMember(t => t.Name, m => m.MapFrom(t => t.Name))
				.ForMember(t => t.Description, m => m.MapFrom(t => t.Description))
				.ForMember(t => t.CourtId, m => m.MapFrom(t => t.CourtsId))
				.ForMember(t => t.CourtStartTime, m => m.MapFrom(t => t.CourtStartTime))
				.ForMember(t => t.CourtEndTime, m => m.MapFrom(t => t.CourtEndTime))
				.ForMember(t => t.SlotDuration, m => m.MapFrom(t => t.SlotDuration));
			//.ForMember(t => t.CompanyId, m => m.MapFrom(t => t.CompanyId));
			//Get CourtBookings List Query
			#endregion

			#region DayTimeSChedule

			CreateMap<AddDayTimeCommand, DayTimeSchedule>().ReverseMap();
			CreateMap<AddTimeScheduleCommand, DayTimeDays>().ReverseMap();
			CreateMap<AddDayTimeResponse, DayTimeSchedule>().ReverseMap();

			CreateMap<UpdateDayTimeCommand, DayTimeSchedule>().ReverseMap();
			CreateMap<UpdateDayTimeResponse, DayTimeSchedule>().ReverseMap();
			CreateMap<GetDayTimeScheduleReponse, DayTimeSchedule>().ReverseMap();
			CreateMap<DayTimeSchedulesDto, DayTimeSchedule>().ReverseMap();

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
