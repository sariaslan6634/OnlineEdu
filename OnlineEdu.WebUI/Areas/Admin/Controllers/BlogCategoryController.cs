using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOS.BlogCategoryDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Validations;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BlogCategoryController : Controller
    {
        private readonly HttpClient _client = HttpClientInstance.CreateClient();
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("BlogCategorys");
            return View(values);
        }
        public async Task<IActionResult> DeleteBlogCategory(int id)
        {
            await _client.DeleteAsync($"BlogCategorys/{id}");
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateBlogCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCategoryDto dto)
        {
            var validator = new BlogCategoryValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                ModelState.Clear();
                foreach (var x in result.Errors)
                {
                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
                return View();
            }
            await _client.PostAsJsonAsync("BlogCategorys", dto);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> UpdateBlogCategory(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateBlogCategoryDto>($"BlogCategorys/{id}");
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto dto)
        {
            await _client.PutAsJsonAsync($"BlogCategorys", dto);
            return RedirectToAction(nameof(Index));
        }
    }
}
