using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LttFlow.Authorization;
using LttFlow.SeedTimer;

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

        public override void PostInitialize()
        {
            base.PostInitialize();

            var _seedTimerAppService = IocManager.Resolve<ISeedTimerAppService>();
            _seedTimerAppService.GenerateData();
        }
    }
}
