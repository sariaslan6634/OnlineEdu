using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.CourseCategory;
using OnlineEdu.DTO.DTOS.CourseRegisterDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistersController(ICourseRegisterService
        _courseRegisterService, IMapper _mapper) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _courseRegisterService.TGetByIdAsync(id);
            var mappedValue = _mapper.Map<ResultCourseRegisterDto>(value);
            return Ok(mappedValue);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseRegister(int id)
        {
            await _courseRegisterService.TDeleteAsync(id);
            return Ok("Kurs kaydı silindi.");
        }
        [HttpGet("GetMyCourses/{userID}")]
        public async Task<IActionResult> GetMyCourses(int userID)
        {
            var values = await _courseRegisterService.TGetAllWithCourseAndCategory(x => x.AppUserId == userID);
            var mappedValue = _mapper.Map<List<ResultCourseRegisterDto>>(values);
            return Ok(mappedValue);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterToCourse(CreateCourseRegisterDto createCourseRegisterDto)
        {
            var newCourseRegister = _mapper.Map<CourseRegister>(createCourseRegisterDto);
            await _courseRegisterService.TCreateAsync(newCourseRegister);
            return Ok("Kursa kayıt başarılı.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourseRegister(UpdateCourseRegisterDto updateCourseRegisterDto)
        {
            var update = _mapper.Map<CourseRegister>(updateCourseRegisterDto);
            await _courseRegisterService.TUpdateAsync(update);
            return Ok("Kurs kaydı güncellendi.");
        }
    }
}
