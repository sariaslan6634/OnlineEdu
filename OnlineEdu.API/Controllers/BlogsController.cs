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
    public class BlogsController : ControllerBase
    {
        private readonly IGenericService<Blog> _blogservice;
        private readonly IMapper _mapper;

        public BlogsController(IGenericService<Blog> service, IMapper mapper)
        {
            _blogservice = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _blogservice.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _blogservice.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto blogDto)
        {
            var values = _mapper.Map<Blog>(blogDto);
            await _blogservice.TCreateAsync(values);
            return Ok("Blog alanı eklendi!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogDto blogDto)
        {
            var values = _mapper.Map<Blog>(blogDto);
            await _blogservice.TUpdateAsync(values);
            return Ok("Blog alanı güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogservice.TDeleteAsync(id);
            return Ok("Blog alanı silindi!");
        }
    }
}
