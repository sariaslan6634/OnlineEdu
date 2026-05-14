using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.Course
{
    public class UpdateCourseDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }


        //category table injection
        public int CourseCategoryId { get; set; }

        //category table injection
    }
}
