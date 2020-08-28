using AutoMapper;
using MemeSharingAPI.Data.Dtos;
using MemeSharingAPI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemeSharingAPI.Data.Mapper_Profiles
{
    public class MemeTypeProfile : Profile
    {
        public MemeTypeProfile()
        {
            CreateMap<MemeType, MemeTypeReadDto>();
        }
    }
}
