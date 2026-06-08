using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDtos;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogAllBlogs :ViewComponent
    {
        private readonly HttpClient _client;

        public _BlogAllBlogs(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");            
            return View(blogs);
        }
    }
}
