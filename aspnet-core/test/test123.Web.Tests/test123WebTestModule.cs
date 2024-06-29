using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using test123.EntityFrameworkCore;
using test123.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace test123.Web.Tests
{
    [DependsOn(
        typeof(test123WebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class test123WebTestModule : AbpModule
    {
        public test123WebTestModule(test123EntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(test123WebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(test123WebMvcModule).Assembly);
        }
    }
}