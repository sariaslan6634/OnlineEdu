using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOS.AboutDtos;
using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOS.TeacherSocialDtos;

namespace OnlineEdu.API.Mapping
{
    public class TeacherSocialMediaMapping:Profile
    {
        public TeacherSocialMediaMapping()
        {
            CreateMap<TeacherSocial, CreateTeacherSocialDto>().ReverseMap();
            CreateMap<TeacherSocial, UpdateTeacherSocialDto>().ReverseMap();
            CreateMap<TeacherSocial, ResultTeacherSocialDto>().ReverseMap();
        }
    }
}
