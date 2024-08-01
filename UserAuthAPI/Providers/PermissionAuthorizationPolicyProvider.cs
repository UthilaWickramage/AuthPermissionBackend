using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace UserAuthAPI.Providers
{
    public class PermissionAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
    {
        public PermissionAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
        {
        }
        public override async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            AuthorizationPolicy? policy = await base.GetPolicyAsync(policyName);
            if (policy is not null)
            {
                return null;
            }

            if (Enum.TryParse<Permissions>(policyName, out var permission))
            {
                return new AuthorizationPolicyBuilder()
                    .AddRequirements(new PermissionRequirement(permission))
                    .Build();
            }
            else
            {
                return null;
            }
        }
    }
}
