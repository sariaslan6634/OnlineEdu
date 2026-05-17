using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DataAccess.concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly OnlineEduContext _educontext;
        public CourseRepository(OnlineEduContext _context) : base(_context)
        {
            _educontext = _context;
        }

        public async Task DontShowOnHome(int id)
        {
            var value = await _educontext.Courses.FindAsync(id);
            value.IsActive = false;
            await _educontext.SaveChangesAsync();
        }

        public async Task ShowOnHome(int id)
        {
            var value = await _educontext.Courses.FindAsync(id);
            value.IsActive = true;
            await _educontext.SaveChangesAsync();
        }
    }
}
