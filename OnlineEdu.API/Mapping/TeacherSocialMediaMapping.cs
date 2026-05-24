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
            CreateMap<TeacherSocial, CreateTeacherSocialMedia>().ReverseMap();
            CreateMap<TeacherSocial, UpdateTeacherSocialMedia>().ReverseMap();
            CreateMap<TeacherSocial, ResultTeacherSocialMedia>().ReverseMap();
        }
    }
}
