using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.MessageDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IGenericService<Message> _messageService;
        private readonly IMapper _mapper;

        public MessagesController(IGenericService<Message> messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _messageService.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _messageService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateMessageDto dto) 
        {
            var value = _mapper.Map<Message>(dto);
            await _messageService.TCreateAsync(value);
            return Ok("Mesaj alanı oluşturuldu!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateMessageDto dto)
        {
            var value = _mapper.Map<Message>(dto);
            await _messageService.TUpdateAsync(value);
            return Ok("Mesaj alanı güncellendi!");

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _messageService.TDeleteAsync(id);
            return Ok("Mesaj alanı güncelelndi!");
        }

    }
}
