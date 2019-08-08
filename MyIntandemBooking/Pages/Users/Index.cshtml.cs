using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyIntandemBooking.Authorization;
using MyIntandemBooking.Services;
using MyIntandemBooking.ViewModels;

namespace MyIntandemBooking.Pages.Users
{
    [Authorize(Roles = Constants.AdministratorsRole)]
    public class IndexModel : PageModel
    {
        private readonly UserService _service;

        public IndexModel(UserService service)
        {
            _service = service;
        }

        public IList<UserViewModel> Users { get; set; }

        public async Task OnGetAsync()
        {
            Users = await _service.GetAllUsersAsync();
        }
    }
}