using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.MessageDtos;
using OnlineEdu.DTO.DTOS.SocialMediaDto;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IGenericService<SocialMedia> _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediasController(IGenericService<SocialMedia> socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _socialMediaService.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _socialMediaService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto dto)
        {
            var value = _mapper.Map<SocialMedia>(dto);
            await _socialMediaService.TCreateAsync(value);
            return Ok("Sosyal media alanı oluşturuldu!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSocialMediaDto dto)
        {
            var value = _mapper.Map<SocialMedia>(dto);
            await _socialMediaService.TUpdateAsync(value);
            return Ok("Sosyal media alanı güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _socialMediaService.TDeleteAsync(id);
            return Ok("Sosyal media alanı silindi!");
        }
    }
}
