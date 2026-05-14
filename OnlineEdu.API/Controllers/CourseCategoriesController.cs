using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.AboutDtos;
using OnlineEdu.DTO.DTOS.CourseCategory;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController : ControllerBase
    {
        private readonly IGenericService<CourseCategory> _courseService;
        private readonly IMapper _mapper;

        public CourseCategoriesController(IGenericService<CourseCategory> courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _courseService.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseService.TGetByIdAsync(id);
            if (value == null)
                return NotFound();
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.TDeleteAsync(id);
            return Ok("Kursa ait Kategorler Alanı silindi");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCategoryDto dto)
        {
            var newValue = _mapper.Map<CourseCategory>(dto);
            await _courseService.TCreateAsync(newValue);
            return Ok("Kursa ait Kategorler Alanı oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseCategoryDto dto)
        {
            var newValue = _mapper.Map<CourseCategory>(dto);
            await _courseService.TUpdateAsync(newValue);
            return Ok("Kursa ait Kategorler Alanı güncellendi");
        }
    }
}
