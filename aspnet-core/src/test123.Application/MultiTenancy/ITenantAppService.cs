using Abp.Application.Services;
using test123.MultiTenancy.Dto;

namespace test123.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

