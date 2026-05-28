using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task ShowOnHome(int id);
        Task DontShowOnHome(int id);
        Task<List<Course>> GetAllCoursesWithCatagoriesAsync();
        Task<List<Course>> GetAllCoursesWithCatagoriesAsync(Expression<Func<Course, bool>> filter = null);
        Task<List<Course>> GetCoursesByTeacherId(int id);

    }
}
