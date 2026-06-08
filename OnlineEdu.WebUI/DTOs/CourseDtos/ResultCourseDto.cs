using OnlineEdu.WebUI.DTOs.CourseCategoryDtos;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.DTOs.CourseDtos
{
    public class ResultCourseDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int CourseCategoryId { get; set; }
        public ResultCourseCategoryDto Category { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }

        public int AppUserId { get; set; }
        public ResultUserDto AppUser { get; set; }
    }
}
