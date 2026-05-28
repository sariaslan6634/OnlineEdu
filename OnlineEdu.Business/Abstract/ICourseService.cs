using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        Task TShowOnHome(int id);
        Task TDontShowOnHome(int id);

        Task<List<Course>> TGetAllCoursesWithCatagoriesAsync();
        Task<List<Course>> TGetAllCoursesWithCatagoriesAsync(Expression<Func<Course, bool>> filter = null);
        Task<List<Course>> TGetCoursesByTeacherId(int id);
    }
}
