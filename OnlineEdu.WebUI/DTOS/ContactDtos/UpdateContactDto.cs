using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.WebUI.DTOS.ContactDtos
{
    public class UpdateContactDto
    {
        public int ContactId { get; set; }
        public string MapUrl { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
