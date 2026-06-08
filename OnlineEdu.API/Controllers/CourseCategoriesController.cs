using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseCategoryDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Authorize(Roles = "Admin, Teacher")]
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _courseCategoryService.TGetListAsync();
            var courseCategories = _mapper.Map<List<ResultCourseCategoryDto>>(values);
            return Ok(courseCategories);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseCategoryService.TGetByIdAsync(id);
            if (value == null)
                return NotFound();

            var mapperValues = _mapper.Map<ResultCourseCategoryDto>(value);
            return Ok(mapperValues);
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
        [AllowAnonymous]
        [HttpGet("GetActiveCategories")]
        public async Task<IActionResult> GetActiveCategories()
        {
            var values = await _courseCategoryService.TGetFilteredListAsync(x => x.IsActive == true);

            var mapperValues = _mapper.Map<List<ResultCourseCategoryDto>>(values);
            return Ok(mapperValues);
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCategoryCount")]
        public async Task<IActionResult> GetCourseCategoryCount()
        {
            var values = await _courseCategoryService.TCountAsync();
            return Ok(values);
        }
    }
}
