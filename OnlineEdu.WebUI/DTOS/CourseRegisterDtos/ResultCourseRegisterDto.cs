using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.Course;

namespace OnlineEdu.WebUI.DTOS.CourseRegisterDtos
{
    public class ResultCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }

        //Course Tablosu
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }

        //öğrenci tablosu
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
