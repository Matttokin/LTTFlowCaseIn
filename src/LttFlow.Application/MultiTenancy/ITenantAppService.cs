using Abp.Application.Services;
using LttFlow.MultiTenancy.Dto;

namespace LttFlow.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

