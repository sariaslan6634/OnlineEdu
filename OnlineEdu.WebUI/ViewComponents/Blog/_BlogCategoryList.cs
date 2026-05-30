using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.BlogCategoryDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogCategoryList :ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryLisyt = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategorys");

            var blogCategories = (from x in categoryLisyt
                                  select new BlogCategoryWithCountViewModal
                                  {
                                      CategoryName = x.Name,
                                      BlogCount = x.Blogs.Count
                                  }).ToList();

            return View(blogCategories);
        }
    }
}
