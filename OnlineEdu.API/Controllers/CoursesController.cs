using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Authorize(Roles = "Admin,Teacher,Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IMapper _mapper;

        public CoursesController(ICourseService courseService, IMapper mapper)
        {
            _courseService = courseService;
            _mapper = mapper;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _courseService.TGetAllCoursesWithCatagoriesAsync();
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseService.TGetByIdAsync(id);
            if (value == null)
                return NotFound();

            var courses = _mapper.Map<ResultCourseDto>(value);
            return Ok(courses);
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

        [HttpGet("ShowOnHome/{id}")]
        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _courseService.TShowOnHome(id);
            return Ok("Ana sayfada Gösteriliyor.");
        }
        [HttpGet("DontShowOnHome/{id}")]
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _courseService.TDontShowOnHome(id);
            return Ok("Ana sayfada gösterilmiyor.");
        }
        [AllowAnonymous]
        [HttpGet("GetActiveCourses")]
        public async Task<IActionResult> GetActiveCourses()
        {
            var values = await _courseService.TGetFilteredListAsync(x => x.IsActive == true);
            var courses = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(courses);
        }

        [HttpGet("GetCoursesByTeacherId/{id}")]
        public async Task<IActionResult> GetCoursesByTeacherId(int id)
        {
            var values = await _courseService.TGetCoursesByTeacherId(id);
            var mappedValues = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(mappedValues);
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCount")]
        public async Task<IActionResult> GetCourseCount()
        {
            var courseCount = await _courseService.TCountAsync();
            return Ok(courseCount);
        }
        [AllowAnonymous]
        [HttpGet("GetCoursesByCategoryId/{id}")]
        public async Task<IActionResult> GetCoursesByCategoryId(int id)
        {
            var values = await _courseService.TGetAllCoursesWithCatagoriesAsync(x => x.CourseCategoryId == id);

            var mappedValues = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(mappedValues);
        }
        
    }
}
