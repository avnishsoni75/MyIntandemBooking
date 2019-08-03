using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MyIntandemBooking.Authorization
{
    public static class Operations
    {
        public static OperationAuthorizationRequirement Update =
          new OperationAuthorizationRequirement { Name = Constants.UpdateOperationName };

        public static OperationAuthorizationRequirement Cancel =
          new OperationAuthorizationRequirement { Name = Constants.CancelOperationName };

        public static OperationAuthorizationRequirement Register =
          new OperationAuthorizationRequirement { Name = Constants.RegisterOperationName };
    }
}
