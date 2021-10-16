using System.Threading.Tasks;
using Abp.Application.Services;
using LttFlow.Authorization.Accounts.Dto;

namespace LttFlow.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
