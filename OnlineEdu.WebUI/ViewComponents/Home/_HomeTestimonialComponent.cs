using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOS.TestimonialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeTestimonialComponent :ViewComponent
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("testimonials");
            return View(values);
        }
    }
}
