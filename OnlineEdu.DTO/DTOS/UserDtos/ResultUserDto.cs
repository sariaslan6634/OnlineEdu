using OnlineEdu.Entity.Entities;
using OnlineEdu.DTO.DTOS.TeacherSocialDtos;

namespace OnlineEdu.DTO.DTOS.UserDtos
{
    public class ResultUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public List<ResultTeacherSocialMedia> TeacherSocials { get; set; }

    }
}
