﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyIntandemBooking.Areas.Identity.Data;
using MyIntandemBooking.Models;

namespace MyIntandemBooking.Pages.Events
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
        private readonly MyInTandemBookingContext _context;
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<MyInTandemBookingUser> _userManager;

        public IndexModel(MyInTandemBookingContext context, 
            IAuthorizationService authorizationService,
            UserManager<MyInTandemBookingUser> userManager)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        public IList<Event> Events { get;set; }

        public async Task OnGetAsync()
        {
            Events = await _context.Event
                .Include(x => x.ManagerAssignments)
                .ThenInclude(x => x.User)
                .ToListAsync();
        }
    }
}
