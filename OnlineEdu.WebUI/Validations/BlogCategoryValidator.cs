using FluentValidation;
using OnlineEdu.WebUI.DTOS.BlogCategoryDtos;
namespace OnlineEdu.WebUI.Validations
{
    public class BlogCategoryValidator:AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Blog kategori adı boş bırakılamaz");
            RuleFor(x=>x.Name).MaximumLength(30).WithMessage("Blog kategori adı 30 karekterden fazla olamaz.");
        }
    }
}
