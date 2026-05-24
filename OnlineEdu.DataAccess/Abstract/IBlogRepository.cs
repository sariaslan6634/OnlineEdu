using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        List<Blog> GetBlogsWithCategories();
        List<Blog> GetLast4BlogsWithCategories();
        List<Blog> GetBlogsByCategory(string categoryName);
        Task<List<Blog>> GetBlogsByWriterIdAsync(int id);

    }
}
