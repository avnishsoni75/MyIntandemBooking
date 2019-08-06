using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyIntandemBooking.Areas.Identity.Data;
using MyIntandemBooking.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace MyIntandemBooking.Models
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, string testUserPw)
        {
            using (var context = new MyInTandemBookingContext(
                serviceProvider.GetRequiredService<DbContextOptions<MyInTandemBookingContext>>()))
            {
                // For sample purposes seed both with the same password.
                // Password is set with the following:
                // dotnet user-secrets set SeedUserPW <pw>
                // The admin user can do anything

                var adminID = await EnsureUser(serviceProvider, testUserPw, "Admin", "admin@intandembike.org");
                await EnsureRole(serviceProvider, adminID.Id, Constants.AdministratorsRole);

                var managerID = await EnsureUser(serviceProvider, testUserPw, "Manager", "manager@intandembike.org");

                var captainID = await EnsureUser(serviceProvider, testUserPw, "Captain", "captain@intandembike.org");
                await EnsureRole(serviceProvider, managerID.Id, Constants.CaptainsRole);

                var stokerID = await EnsureUser(serviceProvider, testUserPw, "Stoker", "stoker@intandembike.org");
                await EnsureRole(serviceProvider, managerID.Id, Constants.StokersRole);

                var volID = await EnsureUser(serviceProvider, testUserPw, "Volunteer", "volunteer@intandembike.org");
                await EnsureRole(serviceProvider, managerID.Id, Constants.VolunteersRole);


                if (!context.Event.Any())
                {
                    var cpr = new Event
                    {
                        DateTime = DateTime.Today.AddDays(30),
                        Description = "Description for Central Park Ride in 1 month's time",
                        Location = "Central Park NYC",
                        Name = "Central Park Ride"
                    };
                    var fb = new Event
                    {
                        DateTime = DateTime.Today.AddDays(60),
                        Description = "Description for 5 Borough Ride in 2 month's time",
                        Location = "All 5 Boroughs!",
                        Name = "5 Borough Ride"
                    };
                    var se = new Event
                    {
                        DateTime = DateTime.Today.AddDays(1),
                        Description = "Description for Social Event tomorrow",
                        Location = "Brooklyn Bridge Park",
                        Name = "Social Picnic"
                    };

                    context.Event.AddRange(cpr, fb, se);
                    context.SaveChanges();
                }

                if (!context.ManagerAssignment.Any())
                {
                    var evt = context.Event
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Name == "Central Park Ride");

                    var evtSp = context.Event
                        .AsNoTracking()
                        .FirstOrDefault(x => x.Name == "Social Picnic");

                    context.ManagerAssignment.AddRange(
                        new ManagerAssignment { EventID = evtSp.ID, UserID = volID.Id },
                        new ManagerAssignment { EventID = evtSp.ID, UserID = managerID.Id },
                        new ManagerAssignment { EventID = evt.ID, UserID = managerID.Id });

                    context.SaveChanges();
                }
            }
        }

        private static async Task<MyInTandemBookingUser> EnsureUser(IServiceProvider serviceProvider,
                                                    string testUserPw, string userName, string emailAddress)
        {
            var userManager = serviceProvider.GetService<UserManager<MyInTandemBookingUser>>();

            var user = await userManager.FindByEmailAsync(emailAddress);
            if (user == null)
            {
                user = new MyInTandemBookingUser { Name = userName, UserName = emailAddress, Email = emailAddress, DOB = DateTime.Today };
                var result = await userManager.CreateAsync(user, testUserPw);
            }

            return user;
        }

        private static async Task<IdentityResult> EnsureRole(IServiceProvider serviceProvider,
                                                                      string uid, string role)
        {
            var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

            if (roleManager == null)
            {
                throw new Exception("roleManager null");
            }

            IdentityResult IR;
            if (!await roleManager.RoleExistsAsync(role))
            {
                IR = await roleManager.CreateAsync(new IdentityRole(role));
            }

            var userManager = serviceProvider.GetService<UserManager<MyInTandemBookingUser>>();

            var user = await userManager.FindByIdAsync(uid);

            if (user == null)
            {
                throw new Exception("The testUserPw password was probably not strong enough!");
            }

            IR = await userManager.AddToRoleAsync(user, role);

            return IR;
        }
    }
}
