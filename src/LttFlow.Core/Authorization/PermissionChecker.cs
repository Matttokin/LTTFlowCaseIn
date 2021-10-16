using Abp.Authorization;
using LttFlow.Authorization.Roles;
using LttFlow.Authorization.Users;

namespace LttFlow.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
