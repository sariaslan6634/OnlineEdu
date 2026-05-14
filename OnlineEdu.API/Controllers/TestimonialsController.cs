using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOS.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IGenericService<Testimonial> _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(IGenericService<Testimonial> testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await _testimonialService.TGetListAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _testimonialService.TGetByIdAsync(id);
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto dto)
        {
            var value = _mapper.Map<Testimonial>(dto);
            await _testimonialService.TCreateAsync(value);
            return Ok("Testimonial alanı eklendi!");
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialDto dto)
        {
            var value = _mapper.Map<Testimonial>(dto);
            await _testimonialService.TUpdateAsync(value);
            return Ok("Testimonial alanı güncellendi!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _testimonialService.TDeleteAsync(id);
            return Ok("Testimonial alanı silindi!");
        }
    }
}
