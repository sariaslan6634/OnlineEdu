using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Business.Concrete
{
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseManager(IRepository<Course> _repository, ICourseRepository courseRepository) : base(_repository)
        {
            _courseRepository = courseRepository;
        }

        public async Task TDontShowOnHome(int id)
        {
            await _courseRepository.DontShowOnHome(id);
        }

        public async Task TShowOnHome(int id)
        {
            await _courseRepository.ShowOnHome(id);
        }
    }
}
