using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;

        public SubscribersController(ISubscriberService subscriberService, IMapper mapper)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _subscriberService.TGetListAsync(); 
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _subscriberService.TGetByIdAsync(id);
            return Ok(value);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existing = await _subscriberService.TGetByEmailAsync(dto.Email);
            if (existing != null)
                return BadRequest("Zaten abone oldunuz.");

            var value = _mapper.Map<Subscriber>(dto);
            await _subscriberService.TCreateAsync(value);
            return Ok("Abone olma işlemi başarılı!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateSubscriberDto dto)
        {
            var value = _mapper.Map<Subscriber>(dto);
            await _subscriberService.TUpdateAsync(value);
            return Ok("Takipciler alanı güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _subscriberService.TDeleteAsync(id);
            return Ok("Takipciler alanı silindi!");
        }
    }
}
