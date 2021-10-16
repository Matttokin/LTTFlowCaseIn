using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LttFlow.Configuration.Dto;

namespace LttFlow.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LttFlowAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
