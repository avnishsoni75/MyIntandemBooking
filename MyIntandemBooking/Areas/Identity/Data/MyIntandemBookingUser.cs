using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using MyIntandemBooking.Models;

namespace MyIntandemBooking.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the MyInTandemBookingUser class
    public class MyInTandemBookingUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }

        [PersonalData]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
