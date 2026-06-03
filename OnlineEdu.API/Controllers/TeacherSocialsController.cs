using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.SocialMediaDto;
using OnlineEdu.DTO.DTOS.TeacherSocialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(IGenericService<TeacherSocial> _teacherSocialService,IMapper _mapper) : ControllerBase
    {
        [HttpGet("byTeacherId/{id}")]
        public async Task<IActionResult> GetSocialByTeacherId(int id)
        {
            var values = await _teacherSocialService.TGetFilteredListAsync(x => x.TeacherId == id);
            var mapper = _mapper.Map<List<ResultTeacherSocialDto>>(values);
            return Ok(mapper);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values =await _teacherSocialService.TGetByIdAsync(id);
            var mapper = _mapper.Map<ResultTeacherSocialDto>(values);
            return Ok(mapper);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _teacherSocialService.TDeleteAsync(id);
            return Ok("Sosyal medya alanınız silindi!");
        }
        [HttpPost]
        public async Task<IActionResult> CreateTeacherSocialMedia(CreateTeacherSocialDto createSocialMediaDto)
        {
            var newValue = _mapper.Map<TeacherSocial>(createSocialMediaDto);
            await _teacherSocialService.TCreateAsync(newValue);
            return Ok("Yeni sosyal medya alanınız eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTeacherSocialDto updateTeacherSocialMedia)
        {
            var value = _mapper.Map<TeacherSocial>(updateTeacherSocialMedia);
            await _teacherSocialService.TUpdateAsync(value);
            return Ok("Sosyal medya alanınızı başarılı bir şekilde güncellediniz.");
        }
    }
}
