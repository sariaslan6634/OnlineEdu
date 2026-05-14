using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.SocialMediaDto
{
    public class UpdateSocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
    }
}
