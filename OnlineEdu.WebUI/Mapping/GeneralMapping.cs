using AutoMapper;
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.RoleDtos;

namespace OnlineEdu.WebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<ResultRoleDto,AppRole>().ReverseMap();
            CreateMap<UpdateRoleDto,AppRole>().ReverseMap();
            CreateMap<CreateRoleDto,AppRole>().ReverseMap();
        }
    }
}
