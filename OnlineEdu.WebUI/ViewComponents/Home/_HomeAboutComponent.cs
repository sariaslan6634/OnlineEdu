using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOS.AboutDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeAboutComponent :ViewComponent
    {
        private readonly HttpClient _clinet = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var about = await _clinet.GetFromJsonAsync<List<ResultAboutDto>>("abouts");
            return View(about);
        }
    }
}
