using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DataAccess.concrete
{
    public class CourseCategoryRepository : GenericRepository<CourseCategory> , ICourseCategoryRepository
    {
        private readonly OnlineEduContext _context;

        public CourseCategoryRepository(OnlineEduContext context) : base(context)
        {
            _context = context;
        }

        public async Task DontShowOnHome(int id)
        {
            var value = _context.CourseCategories.Find(id);
            value.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task ShowOnHome(int id)
        {
            var value = _context.CourseCategories.Find(id);
            value.IsActive = true;
            await _context.SaveChangesAsync();
        }
    }
}
