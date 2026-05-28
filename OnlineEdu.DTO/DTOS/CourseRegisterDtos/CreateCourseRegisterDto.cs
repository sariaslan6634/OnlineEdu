using OnlineEdu.DTO.DTOS.Course;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOS.CourseRegisterDtos
{
    public class CreateCourseRegisterDto
    {
        public int CourseId { get; set; }
        public int AppUserId { get; set; }
    }
}
