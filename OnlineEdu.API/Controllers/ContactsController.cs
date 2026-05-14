using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IGenericService<Contact> _contactService;
        private readonly IMapper _mapper;
        public ContactsController(IGenericService<Contact> contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _contactService.TGetListAsync();
            return Ok(results);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contactService.TGetByIdAsync(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto dto)
        {
            var result = _mapper.Map<Contact>(dto);
            await _contactService.TCreateAsync(result);
            return Ok("İletişim alanı eklendi");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto dto)
        {
            var result = _mapper.Map<Contact>(dto);
            await _contactService.TUpdateAsync(result);
            return Ok("İletişim alanı güncellendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.TDeleteAsync(id);
            return Ok("İletişim alanı silindi");
        }
    }
}
