using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.ContactDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ContactController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _client.DeleteAsync("contacts/" + id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto dto)
        {
            await _client.PostAsJsonAsync("contacts", dto);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateContactDto>("contacts/" + id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto dto)
        {
            var value = await _client.PutAsJsonAsync("contacts", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
