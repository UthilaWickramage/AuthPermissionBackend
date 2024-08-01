namespace UserAuthAPI.Model
{
    public class UserRolePermissions
    {
        public int UserRolePermissionsId { get; set; }
        
        public Permission Permission { get; set; }

        public UserRole UserRole { get; set; }
    }
}
