using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace LttFlow.Web.Views
{
    public abstract class LttFlowRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected LttFlowRazorPage()
        {
            LocalizationSourceName = LttFlowConsts.LocalizationSourceName;
        }
    }
}
