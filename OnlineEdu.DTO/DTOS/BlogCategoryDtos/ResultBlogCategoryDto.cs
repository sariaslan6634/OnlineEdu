using OnlineEdu.DTO.DTOS.BlogDtos;
using OnlineEdu.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.BlogCategoryDtos
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }

        public List<ResultBlogDto> Blogs { get; set; }
    }
}
