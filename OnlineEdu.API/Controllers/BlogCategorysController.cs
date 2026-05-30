using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategorysController(IBlogCategoryService _blogCategoryService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _blogCategoryService.TGetCategoriesWithBlogs();
            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _blogCategoryService.TGetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryDto dto)
        {
            var result = _mapper.Map<BlogCategory>(dto);
            await _blogCategoryService.TCreateAsync(result);
            return Ok("Blog categorisi oluşturuldu!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCategoryDto dto)
        {
            var result = _mapper.Map<BlogCategory>(dto);
            await _blogCategoryService.TUpdateAsync(result);
            return Ok("Blog categorisi güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogCategoryService.TDeleteAsync(id);
            return Ok("Blog categorisi silindi!");
        }
    }
}
