using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyIntandemBooking.Helpers;
using MyIntandemBooking.Models;
using MyIntandemBooking.ViewModels;
using System.Threading.Tasks;

namespace MyIntandemBooking.Pages.Wizard
{
    [AllowAnonymous]
    public class CreateWizardUser3Model : PageModel
    {
        private readonly MyIntandemBooking.Models.MyInTandemBookingContext _context;

        public CreateWizardUser3Model(MyIntandemBooking.Models.MyInTandemBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Wizard3 Wizard3 { get; set; }

        public void OnGet()
        {
            var user = HttpContext.Session.GetJson<WizardUser>("WizardUser");

            Wizard3 = new Wizard3
            {
                AgreeToTerms = user.AgreeToTerms
            };
        }

        public async Task<IActionResult> OnPostAsync(string btn)
        {
            if (btn == "previous")
            {
                return RedirectToPage("./CreateWizardUser2");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var wizardUser = HttpContext.Session.GetJson<WizardUser>("WizardUser");
            wizardUser.AgreeToTerms = Wizard3.AgreeToTerms;
            HttpContext.Session.SetJson("WizardUser", wizardUser);

            _context.WizardUser.Add(wizardUser);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("WizardUser");
            return RedirectToPage("/Index");
        }
    }
}