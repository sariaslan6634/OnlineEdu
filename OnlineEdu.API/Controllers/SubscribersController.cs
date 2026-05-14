using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.SubscriberDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribersController : ControllerBase
    {
        private readonly IGenericService<Subscriber> _subscriberService;
        private readonly IMapper _mapper;
        public SubscribersController(IGenericService<Subscriber> subscriberService, IMapper mapper)
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
        [HttpPost]
        public async Task<IActionResult> Create(CreateSubscriberDto dto)
        {
            var value = _mapper.Map<Subscriber>(dto);
            await _subscriberService.TCreateAsync(value);
            return Ok("Takipciler alanı eklendi!");
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
