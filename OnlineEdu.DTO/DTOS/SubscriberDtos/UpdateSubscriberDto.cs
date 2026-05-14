using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.SubscriberDtos
{
    public class UpdateSubscriberDto
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
