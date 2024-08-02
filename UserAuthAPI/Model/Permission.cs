namespace UserAuthAPI.Model
{
    public class Permission
    {
        public int PermissionId { get; set; }

        public string PermissionName { get; set; }

        public ICollection<UserRolePermissions> UserRolePermissions { get; set; }
    }
}
