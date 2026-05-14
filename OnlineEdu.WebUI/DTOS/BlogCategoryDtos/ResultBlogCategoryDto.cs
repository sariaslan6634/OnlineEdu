
using OnlineEdu.WebUI.DTOS.BlogDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.WebUI.DTOS.BlogCategoryDtos
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }

        public List<ResultBlogDto> Blogs { get; set; }
    }
}
