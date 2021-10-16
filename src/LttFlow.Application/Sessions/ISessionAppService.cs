using System.Threading.Tasks;
using Abp.Application.Services;
using LttFlow.Sessions.Dto;

namespace LttFlow.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
