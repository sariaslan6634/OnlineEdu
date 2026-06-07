using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IMapper _mapper, IBlogService _blogService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
        [AllowAnonymous]
        [HttpGet("GetLast4Blogs")]
        public async Task<IActionResult> GetLast4Blogs()
        {
            var values = _blogService.TGetLast4BlogsWithCategories();
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
        [HttpGet("BlogByCategory")]
        public async Task<IActionResult> BlogByCategory(string categoryName)
        {
            var values = _blogService.TGetBlogsByCategory(categoryName);
            var blogs = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(blogs);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogService.TGetBlogsWithCategory(id);
            var blogs = _mapper.Map<ResultBlogDto>(value);

            return Ok(blogs);
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

        [HttpGet("GetBlogByWriterID/{id}")]
        public async Task<IActionResult> GetBlogByWriterID(int id)
        {
            var values = await _blogService.TGetBlogsByWriterIdAsync(id);
            var mappedValues = _mapper.Map<List<ResultBlogDto>>(values);
            return Ok(mappedValues);
        }
        [AllowAnonymous]
        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var blogCount = await _blogService.TCountAsync();
            return Ok(blogCount);
        }
        [AllowAnonymous]
        [HttpGet("GetBlogsByCategoryId/{id}")]
        public async Task<IActionResult> GetBlogsByCategoryId(int id)
        {
            var blogs = await _blogService.TGetBlogsByCategoryId(id);
            var mappedValues = _mapper.Map<List<ResultBlogDto>>(blogs);
            return Ok(mappedValues);
        }
    }
}
