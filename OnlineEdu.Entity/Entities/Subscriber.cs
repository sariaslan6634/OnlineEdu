using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineEdu.Entity.Entities
{
    public class Subscriber
    {
        public int SubscriberId { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
