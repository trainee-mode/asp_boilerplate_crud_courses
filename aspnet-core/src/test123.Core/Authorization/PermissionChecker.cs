using Abp.Authorization;
using test123.Authorization.Roles;
using test123.Authorization.Users;

namespace test123.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
