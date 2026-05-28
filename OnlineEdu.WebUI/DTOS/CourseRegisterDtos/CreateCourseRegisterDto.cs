
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.Course;

namespace OnlineEdu.WebUI.DTOS.CourseRegisterDtos
{
    public class CreateCourseRegisterDto
    {
        public int CourseId { get; set; }
        public int AppUserId { get; set; }
    }
}
