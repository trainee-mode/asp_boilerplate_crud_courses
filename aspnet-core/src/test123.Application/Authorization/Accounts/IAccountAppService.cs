﻿using System.Threading.Tasks;
using Abp.Application.Services;
using test123.Authorization.Accounts.Dto;

namespace test123.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
