using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.WebUI.DTOS.BannerDtos
{
    public class UpdateBannerDto
    {
        public int BannerId { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
    }
}
