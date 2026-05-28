using AutoMapper;
using OnlineEdu.DTO.DTOS.CourseRegisterDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseRegisterMapping : Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<ResultCourseRegisterDto, CourseRegister>().ReverseMap();
            CreateMap<CreateCourseRegisterDto, CourseRegister>().ReverseMap();
            CreateMap<UpdateCourseRegisterDto, CourseRegister>().ReverseMap();
        }
    }
}
