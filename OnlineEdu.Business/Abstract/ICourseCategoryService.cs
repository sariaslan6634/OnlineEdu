using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseCategoryService:IGenericService<CourseCategory>
    {
        Task TShowOnHome(int id);
        Task TDontShowOnHome(int id);
    }
}
