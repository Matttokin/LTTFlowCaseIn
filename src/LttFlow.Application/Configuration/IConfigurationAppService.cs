using System.Threading.Tasks;
using LttFlow.Configuration.Dto;

namespace LttFlow.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
