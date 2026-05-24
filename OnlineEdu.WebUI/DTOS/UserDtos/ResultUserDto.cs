using OnlineEdu.Entity.Entities;
using OnlineEdu.WebUI.DTOS.TeacherSocialDtos;

namespace OnlineEdu.WebUI.DTOS.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public List<ResultTeacherSocialDto> TeacherSocials { get; set; }

    }
}
