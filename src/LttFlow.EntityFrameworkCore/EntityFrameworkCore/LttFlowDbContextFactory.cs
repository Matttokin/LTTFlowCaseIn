using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using LttFlow.Configuration;
using LttFlow.Web;

namespace LttFlow.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LttFlowDbContextFactory : IDesignTimeDbContextFactory<LttFlowDbContext>
    {
        public LttFlowDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LttFlowDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            LttFlowDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LttFlowConsts.ConnectionStringName));

            return new LttFlowDbContext(builder.Options);
        }
    }
}
