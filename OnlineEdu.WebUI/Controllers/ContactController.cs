using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.DTOs.MessageDtos;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> IndexAsync()
        {
            var result = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            ViewBag.map = result.Select(x => x.MapUrl).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto model)
        {
            await _client.PostAsJsonAsync("messages", model);
            return NoContent();
        }
    }
}
