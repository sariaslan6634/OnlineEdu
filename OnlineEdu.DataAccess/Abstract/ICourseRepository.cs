using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task ShowOnHome(int id);
        Task DontShowOnHome(int id);
        Task<List<Course>> GetAllCoursesWithCatagoriesAsync();
        Task<List<Course>> GetCoursesByTeacherId(int id);

    }
}
