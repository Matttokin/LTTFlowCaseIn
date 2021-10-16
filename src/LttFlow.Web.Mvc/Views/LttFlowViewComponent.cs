using Abp.AspNetCore.Mvc.ViewComponents;

namespace LttFlow.Web.Views
{
    public abstract class LttFlowViewComponent : AbpViewComponent
    {
        protected LttFlowViewComponent()
        {
            LocalizationSourceName = LttFlowConsts.LocalizationSourceName;
        }
    }
}
