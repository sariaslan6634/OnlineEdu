using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();
        List<Blog> TGetLast4BlogsWithCategories();
        List<Blog> TGetBlogsByCategory(string categoryName);
        Task<List<Blog>> TGetBlogsByWriterIdAsync(int id);
    }
}
