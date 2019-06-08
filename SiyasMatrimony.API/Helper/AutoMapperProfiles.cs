using AutoMapper;
using DatingApp.API.DTOS;
using SiyasMatrimony.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiyasMatrimony.API.Helper
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
            .ForMember(dest => dest.PhotoUrl, options =>
               {
                   options.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
               })
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom((usr, d) => usr.DateOfBirth.CalculateAge());
                }
            );

            CreateMap<UserForRegisterDto, User>();
            CreateMap<User,UserForDetailedDto>();

        }
    }
}
