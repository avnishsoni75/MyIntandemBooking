using System;
using System.ComponentModel.DataAnnotations;

namespace MyIntandemBooking.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; }

        public string Email { get; set; }

        [Display(Name = "Role(s)")]
        public string Roles { get; set; }
    }
}
