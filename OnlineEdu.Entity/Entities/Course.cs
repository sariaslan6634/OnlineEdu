using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Entity.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }


        //category table injection
        public int CourseCategoryId { get; set; }
        public virtual CourseCategory Category { get; set; }

        //Öğretmen ekleme
        public int? AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        //kurs kayıt tablosu
        public virtual List<CourseRegister> CourseRegister { get; set; }

        //Video kayıt tablosu
        public virtual List<CourseVideo> CourseVideos { get; set; }
    }
}
