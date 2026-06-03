using AutoMapper;
using OnlineEdu.DTO.DTOS.Course;
using OnlineEdu.DTO.DTOS.CourseVideoDtos;
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
