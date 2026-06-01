
using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.CourseCategory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.WebUI.DTOS.Course
{
    public class ResultCourseDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        //category table injection
        public int CourseCategoryId { get; set; }
        public ResultCourseCategoryDto Category { get; set; }
    }
}
