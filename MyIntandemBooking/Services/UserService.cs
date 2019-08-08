using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyIntandemBooking.Areas.Identity.Data;
using MyIntandemBooking.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyIntandemBooking.ViewModels;

namespace MyIntandemBooking.Services
{
    public class UserService
    {
        private readonly MyInTandemBookingContext _context;
        private readonly UserManager<MyInTandemBookingUser> _userManager;

        public UserService(MyInTandemBookingContext context, 
            UserManager<MyInTandemBookingUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IList<UserViewModel>> GetAllUsersAsync()
        {
            var users = from user in await _userManager.Users.ToListAsync()
                        select new UserViewModel
                        {
                            Name = user.Name,
                            DOB = user.DOB,
                            Email = user.Email,
                            Roles = string.Join(',', _userManager.GetRolesAsync(user).Result)
                        };

            return users.ToList();
        }
    }
}
