using AutoMapper;
using OpenTokSDK;
using SpeekIO.Domain.Enums.Video;
using SpeekIO.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpeekIO.Infrastructure.Video.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VideoRole, Role>().ReverseMap();
            CreateMap<VideoArchiveStatus, ArchiveStatus>().ReverseMap();
            CreateMap<VideoOutputMode, OutputMode>().ReverseMap();
            CreateMap<VideoArchive, Archive>().ReverseMap();
        }
    }
}
