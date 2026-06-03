using AutoMapper;
using OnlineEdu.DTO.DTOS.BlogCategoryDtos;
using OnlineEdu.DTO.DTOS.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.API.Mapping
{
    public class BlogCategoryMapping :Profile
    {
        public BlogCategoryMapping()
        {
            CreateMap<Blog, ResultBlogDto>();

            CreateMap<CreateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<UpdateBlogCategoryDto, BlogCategory>().ReverseMap();
            CreateMap<ResultBlogCategoryDto, BlogCategory>().ReverseMap();            
        }
    }
}
