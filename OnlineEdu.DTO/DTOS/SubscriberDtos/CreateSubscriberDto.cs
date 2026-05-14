using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.DTO.DTOS.SubscriberDtos
{
    public class CreateSubscriberDto
    {
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
