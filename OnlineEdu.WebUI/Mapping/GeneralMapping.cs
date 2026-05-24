using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.RoleDtos;
using OnlineEdu.WebUI.DTOS.TeacherSocialDtos;
using OnlineEdu.WebUI.DTOS.UserDtos;

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
