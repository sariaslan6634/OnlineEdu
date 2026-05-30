using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineEdu.DTO.DTOS.SubscriberDtos
{
    public class UpdateSubscriberDto
    {
        public int SubscriberId { get; set; }
        [Required(ErrorMessage = "Email giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
