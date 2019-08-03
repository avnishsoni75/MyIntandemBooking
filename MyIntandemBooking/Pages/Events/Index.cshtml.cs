using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyIntandemBooking.Models;

namespace MyIntandemBooking.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly MyInTandemBookingContext _context;

        public IndexModel(MyInTandemBookingContext context)
        {
            _context = context;
        }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Event.ToListAsync();
        }
    }
}
