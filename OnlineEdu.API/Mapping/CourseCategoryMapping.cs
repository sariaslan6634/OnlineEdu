using AutoMapper;
using OnlineEdu.DTO.DTOS.CourseCategory;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseCategoryMapping:Profile
    {
        public CourseCategoryMapping()
        {
            CreateMap<CreateCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<ResultCourseCategoryDto, CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoryDto, CourseCategory>().ReverseMap();
        }
    }
}
