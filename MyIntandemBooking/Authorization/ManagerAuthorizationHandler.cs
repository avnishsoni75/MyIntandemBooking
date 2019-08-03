using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using MyIntandemBooking.Areas.Identity.Data;
using MyIntandemBooking.Models;

namespace MyIntandemBooking.Authorization
{
    public class ManagerAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Event>
    {
        protected readonly UserManager<MyInTandemBookingUser> _userManager;

        public ManagerAuthorizationHandler(UserManager<MyInTandemBookingUser> userManager)
        {
            _userManager = userManager;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
            OperationAuthorizationRequirement requirement, Event resource)
        {
            if (context.User == null || resource == null)
                return Task.CompletedTask;

            if (requirement.Name != Constants.UpdateOperationName)
                return Task.CompletedTask;

            var userId = _userManager.GetUserId(context.User);
            if (context.User.IsInRole(Constants.AdministratorsRole) || resource.ManagerAssignments.Any(x => x.UserID == userId))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
