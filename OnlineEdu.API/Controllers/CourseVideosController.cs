using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseVideoDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Authorize(Roles = "Admin,Teacher,Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseVideosController(IGenericService<CourseVideo> _courseVideoService, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courseVideos = await _courseVideoService.TGetListAsync();
            var newValue = _mapper.Map<List<ResultCourseVideoDto>>(courseVideos);
            return Ok(newValue);
        }
        [HttpGet("GetCourseVideosByCourseId/{id}")]
        public async Task<IActionResult> GetCourseVideosByCourseId(int id)
        {
            var courseVideos = await _courseVideoService.TGetFilteredListAsync(x => x.CourseId == id);
            var newValue = _mapper.Map<List<ResultCourseVideoDto>>(courseVideos);
            return Ok(newValue);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var courseVideo = await _courseVideoService.TGetByIdAsync(id);
            if (courseVideo == null)
            {
                return NotFound();
            }
            var newValue = _mapper.Map<ResultCourseVideoDto>(courseVideo);
            return Ok(newValue);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseVideoService.TDeleteAsync(id);
            return Ok("Video Silindi");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseVideoDto dto)
        {
            var newValue = _mapper.Map<CourseVideo>(dto);
            await _courseVideoService.TCreateAsync(newValue);
            return Ok("Video Eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCourseVideoDto dto)
        {
            var value = _mapper.Map<CourseVideo>(dto);
            await _courseVideoService.TUpdateAsync(value);
            return Ok("Video Güncellendi");
        }
    }
}
