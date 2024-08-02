using Microsoft.AspNetCore.Authorization;

namespace UserAuthAPI
{
    public class HasPermissionAttribute:AuthorizeAttribute
    {
        public HasPermissionAttribute(Permissions permissions) :base(policy: permissions.ToString())
        {

        }
        
            
        }
    }

