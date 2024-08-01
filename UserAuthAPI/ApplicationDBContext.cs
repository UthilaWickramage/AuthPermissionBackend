using Microsoft.EntityFrameworkCore;
using UserAuthAPI.Model;

namespace UserAuthAPI
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public ApplicationDBContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRolePermissions> UserRolePermissions { get; set; }
    }
}
