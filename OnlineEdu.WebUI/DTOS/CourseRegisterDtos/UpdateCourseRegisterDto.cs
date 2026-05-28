using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.Course;

namespace OnlineEdu.WebUI.DTOS.CourseRegisterDtos
{
    public class UpdateCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }

        public int CourseId { get; set; }
        public int AppUserId { get; set; }
    }
}
