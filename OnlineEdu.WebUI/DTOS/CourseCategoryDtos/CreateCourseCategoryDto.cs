using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.WebUI.DTOS.CourseCategory
{
    public class CreateCourseCategoryDto
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
