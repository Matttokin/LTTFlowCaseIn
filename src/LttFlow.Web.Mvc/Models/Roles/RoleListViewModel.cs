using System.Collections.Generic;
using LttFlow.Roles.Dto;

namespace LttFlow.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
