using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogCategoryList :ViewComponent
    {
        private readonly HttpClient _client;

        public _BlogCategoryList(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryLisyt = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogcategorys");

            var blogCategories = (from x in categoryLisyt
                                  select new BlogCategoryWithCountViewModal
                                  {

                                      CategoryName = x.Name,
                                      BlogCount = x.Blogs.Count,
                                      BlogCategoryId = x.BlogCategoryId
                                  }).ToList();

            return View(blogCategories);
        }
    }
}
