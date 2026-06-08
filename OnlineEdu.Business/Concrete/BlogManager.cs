using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System;
using System.Text;

namespace OnlineEdu.Business.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogManager(IRepository<Blog> _repository, IBlogRepository blogRepository) : base(_repository)
        {
            _blogRepository = blogRepository;
        }

        public List<Blog> TGetBlogsByCategory(string categoryName)
        {
            return _blogRepository.GetBlogsByCategory(categoryName);
        }

        public async Task<List<Blog>> TGetBlogsByCategoryId(int id)
        {
            return await _blogRepository.GetBlogsByCategoryId(id);
        }

        public Task<List<Blog>> TGetBlogsByWriterIdAsync(int id)
        {
            return _blogRepository.GetBlogsByWriterIdAsync(id);
        }

        public List<Blog> TGetBlogsWithCategories()
        {
            return _blogRepository.GetBlogsWithCategories();
        }

        public async Task<Blog> TGetBlogsWithCategory(int id)
        {
            return await _blogRepository.GetBlogsWithCategory(id);
        }

        public async Task<List<Blog>> TGetLast4BlogsWithCategories()
        {
            return await _blogRepository.GetLast4BlogsWithCategories();
        }
    }
}
