using OnlineEdu.DTO.DTOS.BlogCategoryDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.BlogDtos
{
    public class UpdateBlogDto
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime BlogDate { get; set; }
        public int BlogCategoryId { get; set; }
    }
}
