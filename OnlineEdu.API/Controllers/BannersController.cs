using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.BannerDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IGenericService<Banner> _bannerService;
        private readonly IMapper _mapper;

        public BannersController(IGenericService<Banner> bannerService, IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _bannerService.TGetListAsync();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bannerService.TGetByIdAsync(id);
            return Ok(result);

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            var result = _mapper.Map<Banner>(createBannerDto);
            await _bannerService.TCreateAsync(result);
            return Ok("Banner Oluşturuldu!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            var result = _mapper.Map<Banner>(updateBannerDto);
            await _bannerService.TUpdateAsync(result);
            return Ok("Banner alanı güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bannerService.TDeleteAsync(id);
            return Ok("Banner alanı silindi");
        }
    }
}
