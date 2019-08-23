using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CreateWizardUser1Model : PageModel
    {
        [BindProperty]
        public Wizard1 Wizard1 { get; set; }

        public void OnGet()
        {
            var user = HttpContext.Session.GetJson<WizardUser>("WizardUser");

            if (user == null)
            {
                HttpContext.Session.SetJson("WizardUser", new WizardUser());
            }
            else
            {
                Wizard1 = new Wizard1
                {
                    Name = user.Name,
                    AddressLine1 = user.AddressLine1,
                    AddressLine2 = user.AddressLine2,
                    City = user.City,
                    NumOfYearsAtAddress = user.NumOfYearsAtAddress
                };
            }
        }

        public IActionResult OnPost(string btn)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var wizardUser = HttpContext.Session.GetJson<WizardUser>("WizardUser");
            wizardUser.Name = Wizard1.Name;
            wizardUser.AddressLine1 = Wizard1.AddressLine1;
            wizardUser.AddressLine2 = Wizard1.AddressLine2;
            wizardUser.City = Wizard1.City;
            wizardUser.NumOfYearsAtAddress = Wizard1.NumOfYearsAtAddress;
            HttpContext.Session.SetJson("WizardUser", wizardUser);

            return RedirectToPage("./CreateWizardUser2");
        }
    }
}