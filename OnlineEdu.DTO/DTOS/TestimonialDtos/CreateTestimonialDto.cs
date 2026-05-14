using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
        public int Start { get; set; }
    }
}
