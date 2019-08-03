using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MyIntandemBooking.Areas.Identity.Data;
using MyIntandemBooking.Models;

namespace MyIntandemBooking.Pages.Events
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<MyInTandemBookingUser> _userManager;
        private readonly MyInTandemBookingContext _context;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(UserManager<MyInTandemBookingUser> userManager,
            MyInTandemBookingContext context,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var user = await _userManager.GetUserAsync(User);

            _logger.LogInformation($"User {user.Id} registered for event {id}");
            var enrollment = new Enrollment { EventID = id, UserID = user.Id };
            await _context.Enrollment.AddAsync(enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}