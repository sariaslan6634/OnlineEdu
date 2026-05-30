using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Business.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();
        Task<Blog> TGetBlogsWithCategory(int id);
        List<Blog> TGetLast4BlogsWithCategories();
        List<Blog> TGetBlogsByCategory(string categoryName);
        Task<List<Blog>> TGetBlogsByWriterIdAsync(int id);
        Task<List<Blog>> TGetBlogsByCategoryId(int id);
    }
}
