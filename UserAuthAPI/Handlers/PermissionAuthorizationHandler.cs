using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.ConstrainedExecution;
using UserAuthAPI.Model;

namespace UserAuthAPI.Handlers
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            var permissions = context.User.Claims
            .Where(c => c.Type == "Permissions")
            .SelectMany(c => c.Value.Split(','))
            .ToHashSet();

      
            if (permissions.Contains(requirement.Permission.ToString()))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
