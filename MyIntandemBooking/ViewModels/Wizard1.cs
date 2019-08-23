using System.ComponentModel.DataAnnotations;

namespace MyIntandemBooking.ViewModels
{
    public class Wizard1
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public int NumOfYearsAtAddress { get; set; }
    }
}
