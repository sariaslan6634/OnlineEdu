using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDtos;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeTeacherComponent : ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeTeacherComponent(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultUserDto>>("users/Get4Teachers");
            return View(values);
        }
    }
}
