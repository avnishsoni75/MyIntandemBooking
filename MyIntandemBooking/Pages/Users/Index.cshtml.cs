using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyIntandemBooking.Areas.Identity.Data;
using MyIntandemBooking.Authorization;
using MyIntandemBooking.Models;

namespace MyIntandemBooking.Pages.Users
{
    [Authorize(Roles = Constants.AdministratorsRole)]
    public class IndexModel : PageModel
    {
        private readonly MyInTandemBookingContext _context;
        private readonly UserManager<MyInTandemBookingUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IndexModel(MyInTandemBookingContext context,
            UserManager<MyInTandemBookingUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IList<MyInTandemBookingUser> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _userManager.Users.ToListAsync();
        }
    }
}