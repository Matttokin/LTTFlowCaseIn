using System.Collections.Generic;
using LttFlow.Roles.Dto;

namespace LttFlow.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}