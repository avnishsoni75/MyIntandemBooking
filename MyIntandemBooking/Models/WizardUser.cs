using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntandemBooking.Models
{
    public class WizardUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int NumOfYearsAtAddress { get; set; }

        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }

        public string AgreeToTerms { get; set; }
    }
}
