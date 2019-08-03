using MyIntandemBooking.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyIntandemBooking.Models
{
    public class ManagerAssignment
    {
        [ForeignKey("MyInTandemBookingUser")]
        public string UserID { get; set; }

        public int EventID { get; set; }

        public MyInTandemBookingUser User { get; set; }

        public Event Event { get; set; }
    }
}
