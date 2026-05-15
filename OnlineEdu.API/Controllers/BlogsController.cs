using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper, IBlogService _blogService) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto blogDto)
        {
            var values = _mapper.Map<Blog>(blogDto);
            await _blogService.TCreateAsync(values);
            return Ok("Blog alanı eklendi!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogDto blogDto)
        {
            var values = _mapper.Map<Blog>(blogDto);
            await _blogService.TUpdateAsync(values);
            return Ok("Blog alanı güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.TDeleteAsync(id);
            return Ok("Blog alanı silindi!");
        }
    }
}
