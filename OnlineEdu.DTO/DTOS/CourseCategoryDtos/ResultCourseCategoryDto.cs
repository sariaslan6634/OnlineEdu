using OnlineEdu.DTO.DTOS.Course;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.CourseCategory
{
    public class ResultCourseCategoryDto
    {
        public int CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public List<ResultCourseDto> Courses { get; set; }
    }
}
