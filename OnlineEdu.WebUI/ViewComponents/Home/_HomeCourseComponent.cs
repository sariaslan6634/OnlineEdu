using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDtos;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCourseComponent:ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeCourseComponent(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var value = await _client.GetFromJsonAsync<List<ResultCourseDto>>("courses/GetActiveCourses");
            return View(value);
        
        }
    }
}
