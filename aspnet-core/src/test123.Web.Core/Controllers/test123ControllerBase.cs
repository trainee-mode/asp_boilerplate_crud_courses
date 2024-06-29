using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace test123.Controllers
{
    public abstract class test123ControllerBase: AbpController
    {
        protected test123ControllerBase()
        {
            LocalizationSourceName = test123Consts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
