using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogAllBlogs :ViewComponent
    {
        HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");            
            return View(blogs);
        }
    }
}
