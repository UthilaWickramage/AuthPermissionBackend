namespace UserAuthAPI.Model
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string UserRoleName { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<UserRolePermissions> UserRolePermissions { get; set; }
    }
}
