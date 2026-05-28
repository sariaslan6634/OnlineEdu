using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Abstract
{
    public interface ICourseRegisterService : IGenericService<CourseRegister>
    {
        Task<List<CourseRegister>> TGetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> filter);
    }
}
