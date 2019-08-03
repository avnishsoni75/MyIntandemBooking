﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyIntandemBooking.Models;

namespace MyIntandemBooking.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly MyIntandemBooking.Models.MyInTandemBookingContext _context;

        public DetailsModel(MyIntandemBooking.Models.MyInTandemBookingContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
