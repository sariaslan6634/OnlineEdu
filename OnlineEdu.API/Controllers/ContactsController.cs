using AutoMapper;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.ContactDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{

    [Authorize(Roles = "Admin")]
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
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _contactService.TGetListAsync();
            var mapperValue = _mapper.Map<List<Contact>>(results);
            return Ok(mapperValue);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _contactService.TGetByIdAsync(id);
            if (result == null)
                return NotFound();

            var mapperValue = _mapper.Map<Contact>(result);
            return Ok(mapperValue);
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
