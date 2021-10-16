using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace LttFlow.EntityFrameworkCore
{
    public static class LttFlowDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LttFlowDbContext> builder, string connectionString)
        {
            builder.UseNpgsql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LttFlowDbContext> builder, DbConnection connection)
        {
            builder.UseNpgsql(connection);
        }
    }
}
