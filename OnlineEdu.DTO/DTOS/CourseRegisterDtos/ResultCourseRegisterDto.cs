using OnlineEdu.DTO.DTOS.Course;
using OnlineEdu.DTO.DTOS.UserDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.DTO.DTOS.CourseRegisterDtos
{
    public class ResultCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }

        //Course Tablosu
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }

        //öğrenci tablosu
        public int AppUserId { get; set; }
        public ResultUserDto AppUser { get; set; }
    }
}
