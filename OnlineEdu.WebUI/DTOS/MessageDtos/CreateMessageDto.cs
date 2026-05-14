using System;
using System.Collections.Generic;
using System.Text;
namespace OnlineEdu.WebUI.DTOS.MessageDtos
{
    public class CreateMessageDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
