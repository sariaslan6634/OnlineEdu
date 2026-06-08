using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SubscriberDtos;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client;

        public SubscriberController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSubscriberDto>>("Subscribers");
            return View(values);
        }
        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            var value = await _client.DeleteAsync($"Subscribers/{id}");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ChangeStatusSubscriber(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"Subscribers/{id}");
            value.IsActive = !value.IsActive;
            await _client.PutAsJsonAsync("Subscribers", value);

            return RedirectToAction("Index");
        }
    }
}
