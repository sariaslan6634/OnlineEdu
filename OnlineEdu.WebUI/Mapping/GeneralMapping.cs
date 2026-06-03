using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOS.RoleDtos;
using OnlineEdu.DTO.DTOS.TeacherSocialDtos;
using OnlineEdu.DTO.DTOS.UserDtos;

namespace OnlineEdu.WebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultRoleDto,AppRole>().ReverseMap();
            CreateMap<UpdateRoleDto,AppRole>().ReverseMap();
            CreateMap<CreateRoleDto,AppRole>().ReverseMap();
            CreateMap<ResultUserDto,AppUser>().ReverseMap();
            CreateMap<ResultTeacherSocialDto, TeacherSocial>().ReverseMap();
        }
    }
}
