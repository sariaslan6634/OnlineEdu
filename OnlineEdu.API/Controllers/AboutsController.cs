using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.DTO.DTOS.AboutDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IGenericService<About> _aboutService;
        private readonly IMapper _mapper;

        public AboutsController(IGenericService<About> aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var values =await _aboutService.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _aboutService.TGetByIdAsync(id);
            if (value == null)
                return NotFound();
            return Ok(value);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {           
            await _aboutService.TDeleteAsync(id);
            return Ok("Hakkımızda Alanı silindi");
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutDto createAboutDto)
        {
            var newValue = _mapper.Map<About>(createAboutDto);
            await _aboutService.TCreateAsync(newValue);
            return Ok("Hakkımızda Alanı oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutDto updateAboutDto)
        {
            var newValue = _mapper.Map<About>(updateAboutDto);
            await _aboutService.TUpdateAsync(newValue);
            return Ok("Hakkımızda Alanı güncellendi");
        }
    }
}
