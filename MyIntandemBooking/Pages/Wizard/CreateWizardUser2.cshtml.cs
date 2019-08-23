using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyIntandemBooking.Helpers;
using MyIntandemBooking.Models;
using MyIntandemBooking.ViewModels;

namespace MyIntandemBooking.Pages.Wizard
{
    [AllowAnonymous]
    public class CreateWizardUser2Model : PageModel
    {
        [BindProperty]
        public Wizard2 Wizard2 { get; set; }

        public void OnGet()
        {
            var user = HttpContext.Session.GetJson<WizardUser>("WizardUser");

            Wizard2 = new Wizard2
            {
                CompanyName = user.CompanyName,
                CompanyAddress = user.CompanyAddress,
                CompanyCity = user.CompanyCity
            };
        }

        public IActionResult OnPost(string btn)
        {
            if (btn == "previous")
            {
                return RedirectToPage("./CreateWizardUser1");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var wizardUser = HttpContext.Session.GetJson<WizardUser>("WizardUser");
            wizardUser.CompanyName = Wizard2.CompanyName;
            wizardUser.CompanyAddress = Wizard2.CompanyAddress;
            wizardUser.CompanyCity = Wizard2.CompanyCity;
            HttpContext.Session.SetJson("WizardUser", wizardUser);

            return RedirectToPage("./CreateWizardUser3");
        }
    }
}