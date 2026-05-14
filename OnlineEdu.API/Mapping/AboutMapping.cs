using AutoMapper;
using OnlineEdu.DTO.DTOS.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class AboutMapping :Profile
    {
        public AboutMapping()
        {
            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
        }
    }
}
