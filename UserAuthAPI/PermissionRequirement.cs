using Microsoft.AspNetCore.Authorization;

namespace UserAuthAPI
{
    public class PermissionRequirement:IAuthorizationRequirement
    {
        public Permissions Permission { get; set; }

        public PermissionRequirement(Permissions permission)
        {
            Permission = permission;
        }
    }
}
