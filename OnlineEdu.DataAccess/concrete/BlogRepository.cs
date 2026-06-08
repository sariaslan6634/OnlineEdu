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
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly OnlineEduContext _educontext;
        public BlogRepository(OnlineEduContext _context) : base(_context)
        {
            _educontext = _context;
        }

        public List<Blog> GetBlogsByCategory(string categoryName)
        {
            return _educontext.Blogs.Include(x => x.BlogCategory)
                .Where(x => x.BlogCategory.Name == categoryName).ToList();
        }

        public async Task<List<Blog>> GetBlogsByCategoryId(int id)
        {
            return await _context.Blogs.
                Include(x => x.BlogCategory).
                Include(x => x.Writer).
                Where(x => x.BlogCategoryId == id).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsByWriterIdAsync(int id)
        {
            return await _educontext.Blogs.Include(x => x.BlogCategory).Where(x => x.WriterId == id).ToListAsync();
        }

        public List<Blog> GetBlogsWithCategories()
        {
            return _educontext.Blogs.Include(x => x.BlogCategory).Include(x=>x.Writer).ToList();
        }

        public async Task<Blog> GetBlogsWithCategory(int id)
        {
            return await _educontext.Blogs.
                Include(x => x.BlogCategory).
                Include(x => x.Writer).
                ThenInclude(x=>x.TeacherSocials).
                FirstOrDefaultAsync(x => x.BlogId == id);
        }

        public async Task<List<Blog>> GetLast4BlogsWithCategories()
        {
            return await _educontext.Blogs
                .Include(x => x.BlogCategory)
                .OrderByDescending(x => x.BlogId)
                .Take(4)
                .ToListAsync();
        }
    }
}
