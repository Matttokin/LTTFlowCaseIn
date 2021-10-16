using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using LttFlow.Authorization.Roles;
using LttFlow.Authorization.Users;
using LttFlow.MultiTenancy;

namespace LttFlow.EntityFrameworkCore
{
    public class LttFlowDbContext : AbpZeroDbContext<Tenant, Role, User, LttFlowDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public LttFlowDbContext(DbContextOptions<LttFlowDbContext> options)
            : base(options)
        {
        }
    }
}
