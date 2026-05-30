using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.concrete;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Business.Concrete
{
    public class BlogCategoryManager : GenericManager<BlogCategory>, IBlogCategoryService
    {
        private readonly IBlogCategoryRepository _blogCategoryRepository;

        public BlogCategoryManager(IRepository<BlogCategory> _repository, IBlogCategoryRepository blogCategoryRepository) : base(_repository)
        {
            _blogCategoryRepository = blogCategoryRepository;
        }

        public async Task<List<BlogCategory>> TGetCategoriesWithBlogs()
        {
            return await _blogCategoryRepository.GetCategoriesWithBlogs();
        }
    }
}
