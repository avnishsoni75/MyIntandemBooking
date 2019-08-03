using MyIntandemBooking.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyIntandemBooking.Models
{
    public class Enrollment
    {
        public int ID { get; set; }

        [ForeignKey("MyInTandemBookingUser")]
        public string UserID { get; set; }

        public int EventID { get; set; }

        public MyInTandemBookingUser User { get; set; }

        public Event Event { get; set; }
    }
}
