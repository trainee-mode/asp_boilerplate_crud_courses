using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using test123.Authorization;

namespace test123
{
    [DependsOn(
        typeof(test123CoreModule), 
        typeof(AbpAutoMapperModule))]
    public class test123ApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<test123AuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(test123ApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
