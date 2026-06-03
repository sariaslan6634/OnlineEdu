using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOS.TestimonialDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class TestimonialController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>("Testimonials");
            return View(values);
        }
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _client.DeleteAsync($"Testimonials/" + id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto dto)
        {
            await _client.PostAsJsonAsync("Testimonials", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateTestimonialDto>($"Testimonials/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto dto)
        {
            await _client.PutAsJsonAsync($"testimonials", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
