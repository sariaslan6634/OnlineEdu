using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace OnlineEdu.WebUI.DTOS.SubscriberDtos
{
    public class CreateSubscriberDto
    {
        [Required(ErrorMessage = "Email giriniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email giriniz.")]
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
