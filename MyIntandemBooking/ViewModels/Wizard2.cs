using System.ComponentModel.DataAnnotations;

namespace MyIntandemBooking.ViewModels
{
    public class Wizard2
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string CompanyAddress { get; set; }

        [Required]
        public string CompanyCity { get; set; }
    }
}
