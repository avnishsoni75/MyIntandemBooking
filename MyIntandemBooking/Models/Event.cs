using MyIntandemBooking.Areas.Identity.Data;
using System;
using System.Collections.Generic;

namespace MyIntandemBooking.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Location { get; set; }

        public ICollection<ManagerAssignment> ManagerAssignments { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
