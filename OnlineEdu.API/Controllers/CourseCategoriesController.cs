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
        private readonly ICourseCategoryService _courseCategoryService;
        private readonly IMapper _mapper;

        public CourseCategoriesController(IMapper mapper, ICourseCategoryService courseCategoryService)
        {
            _mapper = mapper;
            _courseCategoryService = courseCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _courseCategoryService.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseCategoryService.TGetByIdAsync(id);
            if (value == null)
                return NotFound();
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseCategoryService.TDeleteAsync(id);
            return Ok("Kursa ait Kategorler Alanı silindi");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseCategoryDto dto)
        {
            var newValue = _mapper.Map<CourseCategory>(dto);
            await _courseCategoryService.TCreateAsync(newValue);
            return Ok("Kursa ait Kategorler Alanı oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseCategoryDto dto)
        {
            var newValue = _mapper.Map<CourseCategory>(dto);
            await _courseCategoryService.TUpdateAsync(newValue);
            return Ok("Kursa ait Kategorler Alanı güncellendi");
        }


        [HttpGet("ShowOnHome/{id}")]
        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _courseCategoryService.TShowOnHome(id);
            return Ok("Ana sayfada gösteriliyor.");               
        }
        [HttpGet("DontShowOnHome/{id}")]
        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _courseCategoryService.TDontShowOnHome(id);
            return Ok("Ana sayfada gösterilmiyor.");
        }
    }
}
