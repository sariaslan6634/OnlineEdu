using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.RoleDtos;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly HttpClient _client;

        public RoleController(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultRoleDto>>("roles");
            return View(values);
        }
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _client.DeleteAsync($"roles/{id}");
            return RedirectToAction("Index");
        }
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleDto createRoleDto)
        {
            await _client.PostAsJsonAsync("roles", createRoleDto);
            return RedirectToAction("Index");
        }
    }
}
