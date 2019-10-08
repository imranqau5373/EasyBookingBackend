using AutoMapper;
using SpeekIO.Application.Commands.Identity.SignUp;
using SpeekIO.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
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
        }
    }
}
