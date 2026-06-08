using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.DTO.DTOs.CourseVideoDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class CourseVideoMapping:Profile
    {
        public CourseVideoMapping()
        {
            CreateMap<ResultCourseDto, Course>().ReverseMap();
            CreateMap<CreateCourseVideoDto, CourseVideo>().ReverseMap();
            CreateMap<UpdateCourseVideoDto, CourseVideo>().ReverseMap();
            CreateMap<ResultCourseVideoDto, CourseVideo>().ReverseMap();
        }
    }
}
