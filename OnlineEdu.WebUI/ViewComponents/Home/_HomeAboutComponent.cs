using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.AboutDtos;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent :ViewComponent
    {
        private readonly HttpClient _client;

        public _HomeAboutComponent(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _client.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(about);
        }
    }
}
