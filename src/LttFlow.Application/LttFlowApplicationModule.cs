using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LttFlow.Authorization;

namespace LttFlow
{
    [DependsOn(
        typeof(LttFlowCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LttFlowApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LttFlowAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LttFlowApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
