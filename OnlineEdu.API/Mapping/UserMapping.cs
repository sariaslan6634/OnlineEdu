using AutoMapper;
using OnlineEdu.DTO.DTOS.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class UserMapping: Profile
    {
        public UserMapping()
        {
            CreateMap<UserRegisterDto, AppUser>().ReverseMap();
            CreateMap<UserLoginDto, AppUser>().ReverseMap();
        }
    }
}
