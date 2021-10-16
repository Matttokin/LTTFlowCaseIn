using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace LttFlow.Controllers
{
    public abstract class LttFlowControllerBase: AbpController
    {
        protected LttFlowControllerBase()
        {
            LocalizationSourceName = LttFlowConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
