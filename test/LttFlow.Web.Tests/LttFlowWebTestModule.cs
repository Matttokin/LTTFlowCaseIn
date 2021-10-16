using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LttFlow.EntityFrameworkCore;
using LttFlow.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace LttFlow.Web.Tests
{
    [DependsOn(
        typeof(LttFlowWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class LttFlowWebTestModule : AbpModule
    {
        public LttFlowWebTestModule(LttFlowEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LttFlowWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(LttFlowWebMvcModule).Assembly);
        }
    }
}