using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseCategoryRepository :IRepository<CourseCategory>
    {
        Task ShowOnHome(int id);
        Task DontShowOnHome(int id);
    }
}
