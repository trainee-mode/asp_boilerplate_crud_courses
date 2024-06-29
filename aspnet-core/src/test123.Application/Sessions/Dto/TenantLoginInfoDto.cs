using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using test123.MultiTenancy;

namespace test123.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}
