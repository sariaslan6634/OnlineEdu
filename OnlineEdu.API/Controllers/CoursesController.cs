using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.AboutDtos;
using OnlineEdu.DTO.DTOS.Course;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IGenericService<Course> _courseService;
        private readonly IMapper _mapper;

        public CoursesController(IGenericService<Course> courseService, IMapper mapper)
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
            return Ok("Kurs Alanı silindi");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseDto dto)
        {
            var newValue = _mapper.Map<Course>(dto);
            await _courseService.TCreateAsync(newValue);
            return Ok("Kurs Alanı oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseDto dto)
        {
            var newValue = _mapper.Map<Course>(dto);
            await _courseService.TUpdateAsync(newValue);
            return Ok("Kurs Alanı güncellendi");
        }
    }
}
