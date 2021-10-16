using System.Collections.Generic;
using LttFlow.Roles.Dto;

namespace LttFlow.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
