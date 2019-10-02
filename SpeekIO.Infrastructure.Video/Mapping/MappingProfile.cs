using AutoMapper;
using OpenTokSDK;
using SpeekIO.Domain.Enums.Video;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Video.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VideoRole, Role>();
        }
    }
}
